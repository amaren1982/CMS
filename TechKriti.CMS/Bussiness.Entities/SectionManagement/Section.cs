using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.SectionManagement;

namespace Bussiness.Entities.SectionManagement
{
    public class Section : ISection
    {
       public int Id { get; set; }       
        public string Name { get; set; }       
        public SectionType SectionType { get; set; }       
    }
}
