﻿using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Datacontracts.ContentManagement
{
    [DataContract]
    public class DeleteMenuResponse
    {
        [DataMember]
        public bool IsDeleted { get; set; }
        [DataMember]
        public LogicalErrorCode FailureReason { get; set; }
    }
}
