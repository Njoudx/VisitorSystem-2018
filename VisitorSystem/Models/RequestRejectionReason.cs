using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VisitorSystem.Models
{
    public class RequestRejectionReason
    {
        public int Id { get; set; }
        public string Reason { get; set; }
        public Request Request { get; set; }
        public int RequestId { get; set; }
    }
}