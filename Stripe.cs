using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Reflection;
using System.Text.Encodings.Web;

namespace LulaCommon.Stripe
{
    public static class Stripe
    {
        static Stripe()
        {
            //System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
        }

        public static void Init(string apiKey)
        {
            APIKey = apiKey;
        }

        private static string APIKey = null;
        private const string BaseURL = "https://api.stripe.com/v1/";

        private static HttpClient _client = null;

        private static HttpClient client
        {
            get
            {
                if (_client == null)
                {
                    _client = new HttpClient(new HttpClientHandler()
                    {
                        AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip,
                    });

                    var byteArray = Encoding.ASCII.GetBytes(APIKey);
                    _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                }
                    

                return _client;
            }
        }

        public static async Task<T> PostAsync<T>(string path, object data)
        {
            var url = BaseURL + path;
            var response = await client.PostAsync(url, new FormUrlEncodedContent(data.ToDictionary()));
            var json = await response.Content.ReadAsStringAsync();
            Console.WriteLine(json);

            return JsonConvert.DeserializeObject<T>(json, new UnixDateTimeConverter());
        }

        public static string GetQueryString(object queryString)
        {
            string q = null;

            if (queryString != null)
            {
                if (queryString is string)
                    q = queryString as string;
                else
                {
                    var dict = queryString.ToDictionary();

                    foreach (var prop in dict)
                    {
                        if (q == null)
                            q = "?";
                        else
                            q += "&";

                        
                        q += UrlEncoder.Default.Encode(prop.Key) + "=" + UrlEncoder.Default.Encode(prop.Value);
                    }
                }
            }

            return q;
        }

        public static async Task<T> GetAsync<T>(string path, object queryString = null)
        {
            var q = GetQueryString(queryString);

            path = path.TrimStart('/');

            var url = BaseURL + path + q;

            var json = await client.GetStringAsync(url);

            //Console.WriteLine(json);

            return JsonConvert.DeserializeObject<T>(json, new UnixDateTimeConverter());
        }

        public static async Task RefundAsync(string chargeID, decimal? amount = null)
        {
            if (amount != null)
                amount *= 100;

            await PostAsync<object>("refunds", new
            {
                charge = chargeID,
                amount = ((int?)amount)?.ToString()
            });
        }

        public static async Task<Charge> ChargeAsync(string token, decimal amount, string description = null, string currency = "usd")
        {
            int amt = (int) (amount * 100);

            return await PostAsync<Charge>("charges", new
            {
                source = token,
                amount = amt.ToString(),
                description = description,
                currency = currency
            });

        }

        public static async Task<Charge[]> ListCustomerChargesAsync(string customerID, string startingAfter = null)
        {
            var response = await GetAsync<ListResponse<Charge>>("charges", new
            {
                customer = customerID,
                starting_after = startingAfter
            });

            List<Charge> results = response.data;

            if (response.has_more)
                results.AddRange(await ListCustomerChargesAsync(customerID, results.Last().id));

            return results.ToArray();
        }



        public static async Task<StripeCustomer[]> GetAllCustomersAsync(string startingAfter = null)
        {
            var response = await GetAsync<ListResponse<StripeCustomer>>("customers", new
            {
                limit = 100,
                starting_after = startingAfter
            });

            List<StripeCustomer> results = response.data;

            if (response.has_more)
                results.AddRange(await GetAllCustomersAsync(results.Last().id));

            return results.ToArray();
        }

        public static async Task<StripeCustomer> GetCustomerAsync(string customerID)
        {
            var response = await GetAsync<StripeCustomer>("customers/" + customerID);

            return response;
        }

        public static async Task<StripeCustomer> UpdateCustomerAsync(string customerID, object customer)
        {
            return await PostAsync<StripeCustomer>("customers/" + customerID, customer);
        }

        public static async Task<StripeCustomer> UpdateCustomerAsync(string customerID, StripeCustomer customer)
        {
            return await PostAsync<StripeCustomer>("customers/" + customerID, customer);
        }

        public static Dictionary<string, string> ToDictionary(this object values, bool removeNull = true)
        {
            var result = new Dictionary<string, string>();
            var type = values.GetType();
            var properties = type.GetRuntimeProperties();

            foreach (var property in properties)
            {
                var name = property.Name;
                var value = property.GetValue(values);

                if(value != null || !removeNull)
                    result.Add(name, value.ToString());
            }

            return result;
        }

        public class UnixDateTimeConverter : Newtonsoft.Json.JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(DateTime) || objectType == typeof(DateTime?);
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                if (reader.Value == null)
                    return null;

                long t = 0;

                if (reader.ValueType == typeof(long))
                    t = (long)reader.Value;
                else
                    t = long.Parse(reader.Value.ToString());

                return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(t).ToLocalTime();
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
        }
    }
}
