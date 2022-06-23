using System;
using System.Collections.Generic;

#nullable disable

namespace BilalTask.Models
{
    public partial class CarModel
    {
        public int ModelId { get; set; }
        public int? MakeId { get; set; }
        public string ModelName { get; set; }

        public virtual Carmake Make { get; set; }
    }
}
