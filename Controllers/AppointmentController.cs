using Dental_Clinic.Models;
using Dental_Clinic.Repositories;
using Dental_Clinic.Repositories.Impl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dental_Clinic.Controllers
{
    [Route("appointments")]
    public class AppointmentController : Controller
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentController(dentalclinicContext context)
        {
            _appointmentRepository = new AppointmentRepository(context);
        }

        [Route("")]
        public ActionResult Index()
        {
            List<AppointmentDetails> appointmentDetails = new List<AppointmentDetails>();
            _appointmentRepository.GetAll().ForEach(a => appointmentDetails.Add(new AppointmentDetails(a)));

            return View(appointmentDetails);
        }

        [Route("{id?}")]
        public ActionResult Details(ulong id)
        {
            Appointment fetched = _appointmentRepository.Get(id);

            if (fetched == null)
            {
                Response.StatusCode = 404;
                var errorMessage = new ErrorViewModel
                {
                    Message = "404 Not Found. " +
                    "We could not find a appointment with an id of " + id + "."

                };
                return View("~/Views/Shared/Error.cshtml", errorMessage);
            }

            return View(new AppointmentDetails(fetched));
        }

        [Route("create")]
        public ActionResult Create()
        {
            return View();
        }

        [Route("create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            Appointment entity = new Appointment();

            entity.PatientId = ulong.Parse(collection["PatientId"]);
            entity.DentistId = ulong.Parse(collection["DentistId"]);
            entity.ScheduledFor = DateTime.Parse(collection["ScheduledFor"]);
            entity.Description = collection["Description"];

            _appointmentRepository.Add(entity);

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
            Appointment appointment = _appointmentRepository.Get(id);

            if (appointment == null)
            {
                Response.StatusCode = 404;
                var errorMessage = new ErrorViewModel
                {
                    Message = "404 Not Found. " +
                    "We could not find a appointment with an id of " + id + "."

                };
                return View("~/Views/Shared/Error.cshtml", errorMessage);
            }

            return View(new AppointmentDetails(appointment));
        }

        [Route("delete/{id?}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ulong id, IFormCollection collection)
        {
            _appointmentRepository.Delete(id);
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
