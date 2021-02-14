using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Egzamin_APBD.Models
{
    public class Prescription_Medicament
    {      
        public int IdMedicament { get; set; }
              
        public int IdPrescription { get; set; }
        public int Dose { get; set; }

        [MaxLength(100)]
        public string Details { get; set; }

        [JsonIgnore]
        public virtual Medicament Medicament { get; set; }
        [JsonIgnore]
        public virtual Prescription Prescription { get; set; }
    }
}
