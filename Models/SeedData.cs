using System;
using System.Collections.Generic;

namespace _213FinalProject.Models
{
    public static class SeedData
    {
        public static IReadOnlyList<Employee> Employees { get; } = new List<Employee>
        {
            new Manager
            {
                EmployeeID = 1,
                FirstName = "Alice",
                LastName = "Johnson",
                Email = "alice.johnson@example.com",
                PhoneNumber = "555-0101",
                HireDate = DateOnly.FromDateTime(DateTime.UtcNow.AddYears(-5)),
                Bio = "Oversees operations and staff.",
                IsActive = true
            },
            new ServicePerforming
            {
                EmployeeID = 2,
                FirstName = "Bob",
                LastName = "Smith",
                Email = "bob.smith@example.com",
                PhoneNumber = "555-0102",
                HireDate = DateOnly.FromDateTime(DateTime.UtcNow.AddYears(-3)),
                Bio = "Senior stylist with 10 years experience.",
                IsActive = true
            },
            new Receptionist
            {
                EmployeeID = 3,
                FirstName = "Cara",
                LastName = "Lopez",
                Email = "cara.lopez@example.com",
                PhoneNumber = "555-0103",
                HireDate = DateOnly.FromDateTime(DateTime.UtcNow.AddYears(-2)),
                Bio = "Front desk and scheduling.",
                IsActive = true
            }
        };

        public static IReadOnlyList<Customer> Customers { get; } = new List<Customer>
        {
            new Customer
            {
                CustomerID = 1,
                FirstName = "Danny",
                LastName = "Green",
                Email = "danny.green@example.com",
                PhoneNumber = "555-0201",
                DateCreated = DateTime.UtcNow.AddMonths(-6),
                PasswordHash = new string('a', 64),
                Notes = "Prefers morning appointments."
            },
            new Customer
            {
                CustomerID = 2,
                FirstName = "Eva",
                LastName = "Brown",
                Email = "eva.brown@example.com",
                PhoneNumber = "555-0202",
                DateCreated = DateTime.UtcNow.AddMonths(-2),
                PasswordHash = new string('b', 64),
                Notes = "Allergic to certain products."
            }
        };

        public static IReadOnlyList<Service> Services { get; } = new List<Service>
        {
            new Service
            {
                ServiceID = 1,
                Name = "Haircut",
                Description = "Standard haircut service.",
                DurationMinutes = 30,
                BasePrice = 25.00m,
                Category = "Hair",
                IsActive = true
            },
            new Service
            {
                ServiceID = 2,
                Name = "Full Color",
                Description = "Professional full-head color treatment.",
                DurationMinutes = 90,
                BasePrice = 120.00m,
                Category = "Color",
                IsActive = true
            }
        };

        public static IReadOnlyList<ServicePerformingEmployeeService> ServicePerformingEmployeeServices { get; } = new List<ServicePerformingEmployeeService>
        {
            new ServicePerformingEmployeeService
            {
                Id = 1,
                EmployeeID = 2, // Bob
                ServiceID = 1  // Haircut
            },
            new ServicePerformingEmployeeService
            {
                Id = 2,
                EmployeeID = 2, // Bob
                ServiceID = 2  // Full Color
            }
        };

        public static IReadOnlyList<Appointment> Appointments { get; } = new List<Appointment>
        {
            new Appointment
            {
                AppointmentID = 1,
                EmployeeID = 2,
                ServiceID = 1,
                CustomerID = 1,
                ScheduledDate = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(3)),
                ScheduledTime = TimeOnly.Parse("09:30"),
                Duration = 30,
                Price = 25.00m
            },
            new Appointment
            {
                AppointmentID = 2,
                EmployeeID = 2,
                ServiceID = 2,
                CustomerID = 2,
                ScheduledDate = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(7)),
                ScheduledTime = TimeOnly.Parse("13:00"),
                Duration = 90,
                Price = 120.00m
            }
        };

        // Utility: get all seeded objects as enumerable
        public static IEnumerable<object> All()
        {
            foreach (var e in Employees) yield return e;
            foreach (var c in Customers) yield return c;
            foreach (var s in Services) yield return s;
            foreach (var sp in ServicePerformingEmployeeServices) yield return sp;
            foreach (var a in Appointments) yield return a;
        }
    }
}
