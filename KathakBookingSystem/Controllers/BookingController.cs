using System;
using KathakBookingSystem.Data;
using KathakBookingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KathakBookingSystem.Controllers
{
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookingController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult ClassEnrollmentForm(int id)
        {
            var selectedClass = _context.Classes.Find(id);
            var selectedClass1 = _context.Classes
                    .Include(c => c.Students)
                    .FirstOrDefault(c => c.ClassID == id);

            Console.WriteLine(selectedClass1.Capacity);
            Console.WriteLine(selectedClass1.Students.Count);

            if (selectedClass1.Students.Count >= selectedClass1.Capacity)
            {
                throw new KathakClassBookingException("Class is fully booked.");
            }

            if (selectedClass == null)
            {
                return NotFound(); // Handle class not found
            }

            return View(selectedClass);
        }

        [HttpPost]
        public IActionResult ClassEnrollmentForm(int id, string name, string email)
        {
            try
            {
                var selectedClass = _context.Classes
                    .Include(c => c.Students)
                    .FirstOrDefault(c => c.ClassID == id);

                if (selectedClass == null)
                {
                    return NotFound(); // Handle class not found
                }

                if (selectedClass.Students.Count >= selectedClass.Capacity)
                {
                    throw new KathakClassBookingException("Class is fully booked.");
                }

                var student = new Student
                {
                    Name = name,
                    Email = email,
                    ClassID = id
                };

                _context.Students.Add(student);
                _context.SaveChanges();

                return RedirectToAction("EnrollmentConfirmation", new { studentId = student.StudentID });
            }
            catch (KathakClassBookingException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(); // Return to the enrollment form with an error message
            }
            catch (Exception ex)
            {
                // Handle other exceptions here, such as database errors
                return View("Error"); // Redirect to an error page
            }
        }

        public IActionResult EnrollmentConfirmation(int studentId)
        {
            var enrolledStudent = _context.Students.Include(s => s.Class).FirstOrDefault(s => s.StudentID == studentId);

            if (enrolledStudent == null)
            {
                return NotFound(); // Handle student not found
            }

            return View(enrolledStudent);
        }
    }
}