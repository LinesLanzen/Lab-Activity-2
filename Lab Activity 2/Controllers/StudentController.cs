using Microsoft.AspNetCore.Mvc;
using Lab_Activity_2.Models;
using System;
using System.Collections.Generic;

namespace Lab_Activity_2.Controllers
{
    public class StudentController : Controller
    {
        // Use a static list to store the students, so it persists between requests
        private static List<Student> students = new List<Student>
        {
            new Student { Id = 1, FirstName = "John", LastName = "Doe", GPA = 3.8, Course = Course.BSIT, AdmissionDate = DateTime.Now, Email = "john@example.com" },
            new Student { Id = 2, FirstName = "Jane", LastName = "Smith", GPA = 3.9, Course = Course.BSCS, AdmissionDate = DateTime.Now, Email = "jane@example.com" }
            // Add more sample students here
        };

        public IActionResult Index()
        {
            // Display the list of students from the static list
            return View(students);
        }

        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                // Generate a unique ID for the new student
                student.Id = students.Count + 1;

                // Add the student to the static list
                students.Add(student);

                // Redirect to the Index action to display the updated list
                return RedirectToAction("Index");
            }

            return View(student);
        }

        public IActionResult Edit(int id)
        {
            // Find the student by ID and pass it to the view for editing
            var student = students.Find(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                // Find the index of the student in the static list
                var index = students.FindIndex(s => s.Id == student.Id);
                if (index != -1)
                {
                    // Update the student in the static list
                    students[index] = student;
                    return RedirectToAction("Index");
                }
            }

            return View(student);
        }

        public IActionResult ShowDetails(int id)
        {
            // Find the student by ID and pass it to the view to show details
            var student = students.Find(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }
    }
}
