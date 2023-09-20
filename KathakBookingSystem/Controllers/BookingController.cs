using System;
using KathakBookingSystem.Data;
using KathakBookingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KathakBookingSystem.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult ClassEnrollmentForm(int id)
        {
            // Write ClassEnrollmentForm functionality here
            // if students count is greater than Class Capacity Throw a exception "Class is fully booked."
            // if class not found return NotFound() else return View()
        }

        [HttpPost]
        public IActionResult ClassEnrollmentForm(int id, string name, string email)
        {
            // Write functionality for adding students
            // Successfull adding redirect to EnrollmentConfirmation with StudentID
            // Handle KathakClassBookingException "Class is fully booked."
        }

        public IActionResult EnrollmentConfirmation(int studentId)
        {
            // Write functionality to display EnrollmentConfirmation student
            // Return NotFound if null else Return View
        }
    }
}
