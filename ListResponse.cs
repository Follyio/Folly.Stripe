using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LulaCommon.Stripe
{
    public class ListResponse<T>
    {
        public string @object { get; set; }
        public List<T> data { get; set; }
        public bool has_more { get; set; }
        public int total_count { get; set; }
        public string url { get; set; }
    }
}
