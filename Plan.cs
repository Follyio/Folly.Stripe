using System;

namespace LulaCommon.Stripe
{
    public class Plan
    {
        public string id { get; set; }
        public string @object { get; set; }
        public int amount { get; set; }
        public DateTime created { get; set; }
        public string currency { get; set; }
        public string interval { get; set; }
        public int interval_count { get; set; }
        public bool livemode { get; set; }
        public Metadata metadata { get; set; }
        public string name { get; set; }
        public string statement_descriptor { get; set; }
        public int? trial_period_days { get; set; }
    }
}