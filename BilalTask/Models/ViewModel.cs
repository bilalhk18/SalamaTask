using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace BilalTask.Models
{
    public class ViewModel
    {
        public ViewModel()
        {
            this.cm = new List<SelectListItem>();
            this.carMol = new List<SelectListItem>();
            this.body = new List<SelectListItem>();
            this.carTrim = new List<SelectListItem>();
        }
        [DisplayName("Car Make")]
        public List<SelectListItem> cm { get; set; }
        [DisplayName("Car Model")]
        public List<SelectListItem> carMol { get; set; }
        [DisplayName("Car Body Type")]
        public List<SelectListItem> body { get; set; }
        [DisplayName("Trim")]
        public List<SelectListItem> carTrim { get; set; }

        public int MakeID { get; set; }
        public int molId { get; set; }
    }
}
