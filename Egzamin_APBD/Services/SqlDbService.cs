using Egzamin_APBD.DTOs.Response;
using Egzamin_APBD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Egzamin_APBD.Services
{
    public class SqlDbService : IDbService
    {
        private readonly MedicamentsDbContext _context;

        public SqlDbService(MedicamentsDbContext context)
        {
            _context = context;
        }

        public Patient DeletePatient(int id)
        {
            var exist = _context.Patients.Any(a => a.IdPatient.Equals(id));
            if (!exist)
            {
                throw new Exception($"Brak pacjenta o numerze id = {id}");
            }
            else
            {
                var pat = _context.Patients.Where(e => e.IdPatient.Equals(id)).First();


               _context.Patients.Remove(pat);
                _context.SaveChanges();

                return pat;
            }
            
        }

        public MedicResponse GetMedicaments(int idMed)
        {
            var exist = _context.Medicaments.Any(a => a.IdMedicament.Equals(idMed));
            if(!exist)
            {
                throw new Exception($"Brak leku o podanym numerze id = {idMed}");
            }
            else
            {
                var medicament = _context.Medicaments.Where(w => w.IdMedicament.Equals(idMed)).Single();
                var mediList = _context.Prescription_Medicaments.Where(w => w.IdMedicament.Equals(idMed)).ToList();

                List<Prescription> presList = new List<Prescription>();

                foreach (var med in mediList)
                {
                    presList.Add(_context.Prescriptions.Single(s => s.IdPrescription.Equals(med.IdPrescription)));
                }

                List<Prescription> listOfPrescriptionsDescendig = new List<Prescription>(presList.OrderByDescending(d => d.Date));

                MedicResponse mdR = new MedicResponse
                {
                    IdMedicament = medicament.IdMedicament,
                    Name = medicament.Name,
                    Description = medicament.Description,
                    Type = medicament.Type,
                    Prescriptions = listOfPrescriptionsDescendig
                };
                return mdR;
            }
        }
    }
}
