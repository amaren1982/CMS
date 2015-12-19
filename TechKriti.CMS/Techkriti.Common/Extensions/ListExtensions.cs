using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Techkriti.Common.Extensions.List
{
    public static class ListExtensions
    {
        public static T Second<T>(this List<T> items) { return items.Skip(1).Take(1).FirstOrDefault(); }

        public static T Third<T>(this List<T> items) { return items.Skip(2).Take(1).FirstOrDefault(); }

        public static T Fourth<T>(this List<T> items) { return items.Skip(3).Take(1).FirstOrDefault();  }
    }
}
