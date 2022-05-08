using Dental_Clinic.Models;
using Dental_Clinic.Repositories;
using Dental_Clinic.Repositories.Impl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dental_Clinic.Controllers
{
    [Route("dentists")]
    public class DentistController : Controller
    {

        private readonly IDentistRepository _dentistRepository;

        public DentistController(dentalclinicContext context)
        {
            _dentistRepository = new DentistRepository(context);
        }

        [Route("")]
        public IActionResult Index()
        {
            List<DentistDetails> dentistDetails = new List<DentistDetails>();
            _dentistRepository.GetAll().ForEach(d => dentistDetails.Add(new DentistDetails(d)));


            return View(dentistDetails);
        }

        [Route("{id?}")]
        public IActionResult Details(ulong id)
        {
            var fetched = _dentistRepository.Get(id);

            if(fetched == null)
            {
                Response.StatusCode = 404;
                var errorMessage = new ErrorViewModel
                {
                    Message = "404 Not Found. " +
                    "We could not find a dentist with an id of " + id + "."

                };
                return View("~/Views/Shared/Error.cshtml", errorMessage);
            }


            var result = new DentistDetails(fetched);

            return View(result);
        }

        [Route("{id?}/patients")]
        public IActionResult Patients(ulong id)
        {
            List<PatientDetails> patientDetails = new List<PatientDetails>();
            _dentistRepository.Get(id).Patients.ToList().ForEach(p => patientDetails.Add(new PatientDetails(p)));

            return View("~/Views/Patient/Index.cshtml", patientDetails);
        }

        [Route("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("create")]
        public IActionResult Create(IFormCollection collection)
        {

            Dentist entity = new Dentist();
            entity.FirstName = collection["FirstName"];
            entity.LastName = collection["LastName"];
            entity.Description = collection["Description"];

            _dentistRepository.Add(entity);

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("~/Views/Shared/Error.cshtml");
            }
        }


        [Route("delete/{id?}")]
        public IActionResult Delete(ulong id)
        {
            var entity = _dentistRepository.Get(id);
            var details = new DentistDetails(entity);

            if(entity == null)
            {
                Response.StatusCode = 404;
                var errorMessage = new ErrorViewModel
                {
                    Message = "404 Not Found. " +
                    "We could not find a dentist with an id of " + id + "."

                };
                return View("~/Views/Shared/Error.cshtml", errorMessage);
            }


            return View(details);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("delete/{id?}")]
        public IActionResult Delete(ulong id, IFormCollection collection)
        {
            _dentistRepository.Delete(id);

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
