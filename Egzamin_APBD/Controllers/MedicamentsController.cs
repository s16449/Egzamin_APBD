using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Egzamin_APBD.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Egzamin_APBD.Controllers
{
    [Route("api")]
    [ApiController]
    public class MedicamentsController : ControllerBase
    {
        public IDbService _service;

        public MedicamentsController(IDbService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("medicaments/{idMedic}")]

        public IActionResult GetMedicaments(int idMedic)
        {
            IActionResult result;

            try
            {
                result = Ok(_service.GetMedicaments(idMedic));
            }
            catch(Exception e)
            {
                result = NotFound($"Brak leku o numerze = {idMedic}");
            }

            return result;
        }

        [HttpDelete]
        [Route("patients/{id}")]

        public IActionResult DeletPatient(int id)
        {
            IActionResult result;

            try
            {
                result = Ok(_service.DeletePatient(id));
            }
            catch (Exception e)
            {
                result = NotFound($"Brak Pacjenta o numerze = {id}");
            }

            return result;
        }
    }
}
