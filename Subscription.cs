using System;

namespace LulaCommon.Stripe
{
    public class Subscription
    {
        public string id { get; set; }
        public string @object { get; set; }
        public decimal? application_fee_percent { get; set; }
        public bool cancel_at_period_end { get; set; }
        public DateTime? canceled_at { get; set; }
        public DateTime? created { get; set; }
        public DateTime? current_period_end { get; set; }
        public DateTime? current_period_start { get; set; }
        public string customer { get; set; }
        public object discount { get; set; }
        public DateTime? ended_at { get; set; }
        public bool livemode { get; set; }
        public Metadata metadata { get; set; }
        public Plan plan { get; set; }
        public int quantity { get; set; }
        public DateTime? start { get; set; }
        public string status { get; set; }
        public decimal? tax_percent { get; set; }
        public DateTime? trial_end { get; set; }
        public DateTime? trial_start { get; set; }

    }
}