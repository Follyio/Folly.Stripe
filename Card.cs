using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LulaCommon.Stripe
{
    public class Card
    {
        public string id { get; set; }
        public string @object { get; set; }
        public string address_city { get; set; }
        public string address_country { get; set; }
        public string address_line1 { get; set; }
        public string address_line1_check { get; set; }
        public string address_line2 { get; set; }
        public string address_state { get; set; }
        public string address_zip { get; set; }
        public string address_zip_check { get; set; }
        public string brand { get; set; }
        public string country { get; set; }
        public string customer { get; set; }
        public string cvc_check { get; set; }
        public string dynamic_last4 { get; set; }
        public int exp_month { get; set; }
        public int exp_year { get; set; }
        public string funding { get; set; }
        public string last4 { get; set; }
        public Metadata metadata { get; set; }
        public string name { get; set; }
        public string tokenization_method { get; set; }
    }
}
