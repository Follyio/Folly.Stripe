using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LulaCommon.Stripe
{
    public class Charge
    {
        public string id { get; set; }
        public string @object { get; set; }
        public int amount { get; set; }
        public int amount_refunded { get; set; }
        public string application { get; set; }
        public string application_fee { get; set; }
        public string balance_transaction { get; set; }
        public bool captured { get; set; }
        public DateTime created { get; set; }
        public string currency { get; set; }
        public string customer { get; set; }
        public string description { get; set; }
        public string destination { get; set; }
        public object dispute { get; set; }
        public string failure_code { get; set; }
        public string failure_message { get; set; }
        public Metadata fraud_details { get; set; }
        public string invoice { get; set; }
        public bool livemode { get; set; }
        public Metadata metadata { get; set; }
        public string order { get; set; }
        public Metadata outcome { get; set; }
        public bool paid { get; set; }
        public string receipt_email { get; set; }
        public string receipt_number { get; set; }
        public bool refunded { get; set; }
        public ListResponse<Refund> refunds { get; set; }
        public string review { get; set; }
        public Metadata shipping { get; set; }
        public Card source { get; set; }
        public string source_transfer { get; set; }
        public string statement_descriptor { get; set; }
        public string status { get; set; }
    }
}
