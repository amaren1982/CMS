using Common.NewsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Entities.NewsManagement
{
    public class News : INews
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public string NewsDescription { get; set; }
        public bool? IsActive { get; set; }
    }
}
