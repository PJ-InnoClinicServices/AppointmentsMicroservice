using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers;

 [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        // GET: api/appointment/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointment(Guid id)
        {
            // Pusta metoda, w przyszłości zaimplementujesz logikę
            return Ok(); // Placeholder
        }

        // GET: api/appointment/patient/{patientId}
        [HttpGet("patient/{patientId}")]
        public async Task<IActionResult> GetAppointmentsForPatient(Guid patientId)
        {
            // Pusta metoda, w przyszłości zaimplementujesz logikę
            return Ok(); // Placeholder
        }

        // GET: api/appointment/doctor/{doctorId}
        [HttpGet("doctor/{doctorId}")]
        public async Task<IActionResult> GetAppointmentsForDoctor(Guid doctorId)
        {
            // Pusta metoda, w przyszłości zaimplementujesz logikę
            return Ok(); // Placeholder
        }

        // POST: api/appointment
        [HttpPost]
        public async Task<IActionResult> CreateAppointment([FromBody] CreateAppointmentDto createAppointmentDto)
        {
            // Pusta metoda, w przyszłości zaimplementujesz logikę
            return Ok(); // Placeholder
        }

        // PUT: api/appointment
        [HttpPut]
        public async Task<IActionResult> UpdateAppointment([FromBody] UpdateAppointmentDto updateAppointmentDto)
        {
            // Pusta metoda, w przyszłości zaimplementujesz logikę
            return Ok(); // Placeholder
        }

        // DELETE: api/appointment/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(Guid id)
        {
            // Pusta metoda, w przyszłości zaimplementujesz logikę
            return Ok(); // Placeholder
        }
    }