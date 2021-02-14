using Egzamin_APBD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Egzamin_APBD.DTOs.Response
{
    public class MedicResponse
    {
        public int IdMedicament { get; set; }
      
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public string Type { get; set; }

       public List<Prescription> Prescriptions { get; set; }
    }
}
