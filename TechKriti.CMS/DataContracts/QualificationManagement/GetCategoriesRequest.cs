﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Datacontracts.QualificationManagement
{
    public class GetCategoriesRequest
    {
        [DataMember]
        public CategorySearchDataContract Filter { get; set; }
    }
}
