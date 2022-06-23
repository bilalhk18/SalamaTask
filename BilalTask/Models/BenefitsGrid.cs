using System;
using System.Collections.Generic;

#nullable disable

namespace BilalTask.Models
{
    public partial class BenefitsGrid
    {
        public int Id { get; set; }
        public string Benefit { get; set; }
        public string Agency { get; set; }
        public string Nonagency { get; set; }
        public string Thirdparty { get; set; }
    }
}
