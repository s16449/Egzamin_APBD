using Egzamin_APBD.DTOs.Response;
using Egzamin_APBD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Egzamin_APBD.Services
{
    public interface IDbService
    {

        public MedicResponse GetMedicaments(int idMed);

        public Patient DeletePatient(int id);
    }
}
