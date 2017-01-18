using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LulaCommon.Stripe
{
    public class StripeEvent
    {
        public string id { get; set; }
        public string @object { get; set; }
        public DateTime created { get; set; }
        public string type { get; set; }
    }
}
