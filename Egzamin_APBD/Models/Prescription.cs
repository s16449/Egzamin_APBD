﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Egzamin_APBD.Models
{
    public class Prescription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPrescription { get; set; }

        public DateTime Date { get; set; }

        public DateTime DueDate { get; set; }

        [ForeignKey("Patient")]
        public int IdPatient { get; set; }
        [ForeignKey("Doctor")]
        public int IdDoctor { get; set; }

        [JsonIgnore]
        public virtual Doctor Doctor { get; set; }
        [JsonIgnore]
        public virtual Patient Patient { get; set; }
        [JsonIgnore]
        public virtual ICollection<Prescription_Medicament> Prescription_Medicaments { get; set; }
    }
}
