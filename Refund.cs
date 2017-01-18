using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LulaCommon.Stripe
{
    public class Refund
    {
        public string id { get; set; }
        public string @object { get; set; }
        public int amount { get; set; }
        public string balance_transaction { get; set; }
        public string charge { get; set; }
        public DateTime created { get; set; }
        public string currency { get; set; }
        public Metadata metadata { get; set; }
        public string reason { get; set; }
        public string receipt_number { get; set; }
        public string status { get; set; }

        public static class Reason
        {
            public const string DUPLICATE = "duplicate";
            public const string FRAUDULENT = "fraudulent";
            public const string REQUESTED_BY_CUSTOMER = "requested_by_customer";
        }
    }
}
