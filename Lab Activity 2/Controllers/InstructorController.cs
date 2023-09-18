using Microsoft.AspNetCore.Mvc;
using Lab_Activity_2.Models;
using System;
using System.Collections.Generic;

namespace Lab_Activity_2.Controllers
{
    public class InstructorController : Controller
    {
        private static List<Instructor> instructors = new List<Instructor>
        {
            new Instructor
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                TenureStatus = TenureStatus.Permanent,
                Rank = Rank.Professor,
                HiringDate = DateTime.Now,
                Email = "john@example.com" // Add email for the first instructor
            },
            new Instructor
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Smith",
                TenureStatus = TenureStatus.Probationary,
                Rank = Rank.AssistantProfessor,
                HiringDate = DateTime.Now,
                Email = "jane@example.com" // Add email for the second instructor
            }
            // Add more sample instructors here
        };

        public IActionResult Index()
        {
            return View(instructors);
        }

        public IActionResult AddInstructor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddInstructor(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                // Assign a unique ID to the new instructor (you may use a better ID generation method)
                instructor.Id = instructors.Count + 1;

                // Add the instructor to the list
                instructors.Add(instructor);

                // Redirect to the Index action to display the updated list
                return RedirectToAction("Index");
            }

            // If the model is not valid, return to the AddInstructor view with validation errors
            return View(instructor);
        }

        public IActionResult Edit(int id)
        {
            // Find the instructor by ID and pass it to the view for editing
            var instructor = instructors.Find(i => i.Id == id);
            if (instructor == null)
            {
                return NotFound();
            }

            return View(instructor);
        }

        [HttpPost]
        public IActionResult Edit(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                // Find the index of the instructor in the list
                var index = instructors.FindIndex(i => i.Id == instructor.Id);

                // If the instructor is not found, return NotFound
                if (index == -1)
                {
                    return NotFound();
                }

                // Update the instructor in the list
                instructors[index] = instructor;

                // Redirect to the Index action to display the updated list
                return RedirectToAction("Index");
            }

            // If the model is not valid, return to the Edit view with validation errors
            return View(instructor);
        }

        public IActionResult ShowDetails(int id)
        {
            // Find the instructor by ID and pass it to the view to show details
            var instructor = instructors.Find(i => i.Id == id);
            if (instructor == null)
            {
                return NotFound();
            }

            return View(instructor);
        }
    }
}



