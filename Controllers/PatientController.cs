using Dental_Clinic.Models;
using Dental_Clinic.Repositories;
using Dental_Clinic.Repositories.Impl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dental_Clinic.Controllers
{
    [Route("patients")]
    public class PatientController : Controller
    {
        private readonly IPatientRepository _patientRepository;

        public PatientController(dentalclinicContext context)
        {
            _patientRepository = new PatientRepository(context);
        }
        [Route("")]
        public ActionResult Index()
        {
            List<PatientDetails> patientDetails = new List<PatientDetails>();
            _patientRepository.GetAll().ForEach(patient => patientDetails.Add(new PatientDetails(patient)));
            return View(patientDetails);
        }

        [Route("{id?}")]
        public ActionResult Details(ulong id)
        {
            Patient patient = _patientRepository.Get(id);

            if (patient == null)
            {
                Response.StatusCode = 404;
                var errorMessage = new ErrorViewModel
                {
                    Message = "404 Not Found. " +
                    "We could not find a patient with an id of " + id + "."

                };
                return View("~/Views/Shared/Error.cshtml", errorMessage);
            }
            return View(new PatientDetails(patient));
        }

        [Route("create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("create")]
        public ActionResult Create(IFormCollection collection)
        {

            Patient entity = new Patient();

            DateOnly birthDate = DateOnly.Parse(collection["BirthDate"]);
            double ageDouble = (DateOnly.FromDateTime(DateTime.Now).DayNumber - birthDate.DayNumber) / 365;
            byte age = ((byte)ageDouble);


            entity.FirstName = collection["FirstName"];
            entity.LastName = collection["LastName"];
            entity.Age = age;
            entity.BirthDate = birthDate;
            entity.DentistId = ulong.Parse(collection["DentistId"]);

            _patientRepository.Add(entity);

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        [Route("delete/{id?}")]
        public ActionResult Delete(ulong id)
        {
            Patient patient = _patientRepository.Get(id);

            if (patient == null)
            {
                Response.StatusCode = 404;
                var errorMessage = new ErrorViewModel
                {
                    Message = "404 Not Found. " +
                    "We could not find a patient with an id of " + id + "."

                };
                return View("~/Views/Shared/Error.cshtml", errorMessage);
            }

            PatientDetails patientDetails = new PatientDetails(patient);
            return View(patientDetails);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("delete/{id?}")]
        public ActionResult Delete(ulong id, IFormCollection collection)
        {
            _patientRepository.Delete(id);

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
