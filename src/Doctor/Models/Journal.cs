using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctor.Models
{
    public class Journal
    {
        public int Id { get; set; }
        public decimal Socker { get; set; }
        public decimal BloodPressure { get; set; }
        public decimal Cholesterol { get; set; }
        public int MyProperty { get; set; }
    }
}
