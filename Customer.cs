using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LulaCommon.Stripe
{
    public class StripeCustomer
    {
        public string id { get; set; }
        public string @object { get; set; }
        public int? account_balance { get; set; }
        public DateTime? created { get; set; }
        public string currency { get; set; }
        public string default_source { get; set; }
        public bool? delinquent { get; set; }
        public string description { get; set; }
        public object discount { get; set; }
        public string email { get; set; }
        public bool? livemode { get; set; }
        public Metadata metadata { get; set; }
        public object shipping { get; set; }
        public ListResponse<Card> sources { get; set; }
        public ListResponse<Subscription> subscriptions { get; set; }
    }
}
