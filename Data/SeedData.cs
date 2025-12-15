using _213FinalProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace _213FinalProject.Data
{
    public static class SeedData
    {
        public static void Initialize(_213FinalProjectContext context)
        {
            // Ensure database is created
            context.Database.EnsureCreated();

            // Seed Employees / Derived types
            if (!context.Employee.Any())
            {
                context.Employee.AddRange(
                    new Manager
                    {
                        //UserID = 1,
                        FirstName = "Alice",
                        LastName = "Johnson",
                        Email = "alice.johnson@example.com",
                        PhoneNumber = "555-0101",
                        HireDate = DateOnly.FromDateTime(DateTime.UtcNow.AddYears(-5)),
                        Bio = "Oversees operations and staff.",
                        IsActive = true,
                        PhotoURL = "https://img.freepik.com/free-photo/happy-joyful-female-woman-with-tablet-posing-indoors_74855-2896.jpg"
                    },
                    new Receptionist
                    {
                        //UserID = 3,
                        FirstName = "Cara",
                        LastName = "Lopez",
                        Email = "cara.lopez@example.com",
                        PhoneNumber = "555-0103",
                        HireDate = DateOnly.FromDateTime(DateTime.UtcNow.AddYears(-2)),
                        Bio = "Front desk and scheduling.",
                        IsActive = true,
                        PhotoURL = "https://img.freepik.com/free-photo/young-adult-casual-wear-standing-with-his-arms-crossed-camera_482257-123008.jpg"
                    },
                    new ServicePerforming
                    {
                        //UserID = 2,
                        FirstName = "Bob",
                        LastName = "Smith",
                        Email = "bob.smith@example.com",
                        PhoneNumber = "555-0102",
                        HireDate = DateOnly.FromDateTime(DateTime.UtcNow.AddYears(-3)),
                        Bio = "Senior stylist with 10 years experience.",
                        IsActive = true,
                        PhotoURL = "https://img.freepik.com/free-photo/portrait-smiling-young-man-wearing-headphones_1262-5371.jpg"
                    },
                    
                    new ServicePerforming
                    {
                        //UserID = 4,
                        FirstName = "Dave",
                        LastName = "Miller",
                        Email = "dave.miller@example.com",
                        PhoneNumber = "555-0104",
                        HireDate = DateOnly.FromDateTime(DateTime.UtcNow.AddYears(-4)),
                        Bio = "Massage therapist specializing in therapeutic techniques.",
                        IsActive = true,
                        PhotoURL = """https://img.freepik.com/free-photo/designer-working-3d-model_23-2149371896.jpg"""
                    },
                new ServicePerforming
                {
                    //UserID = 5,
                    FirstName = "Emma",
                    LastName = "Wilson",
                    Email = "emma.wilson@example.com",
                    PhoneNumber = "555-0105",
                    HireDate = DateOnly.FromDateTime(DateTime.UtcNow.AddMonths(-6)),
                    Bio = "Esthetician focused on facials and skin treatments.",
                    IsActive = true,
                    PhotoURL = """https://img.freepik.com/free-photo/close-up-excited-person-portrait_23-2151186640.jpg"""
                },
                new ServicePerforming
                {
                    //UserID = 6,
                    FirstName = "Fiona",
                    LastName = "Garcia",
                    Email = "fiona.garcia@example.com",
                    PhoneNumber = "555-0106",
                    HireDate = DateOnly.FromDateTime(DateTime.UtcNow.AddYears(-2)),
                    Bio = "Nail technician and waxing specialist.",
                    IsActive = true,
                    PhotoURL = """https://img.freepik.com/free-photo/african-girl-blue-shirt-smiling-posing-with-crossed-arms_176420-11226.jpg"""

                });
                    context.SaveChanges();
                }

                // Seed Customers
                if (!context.Customer.Any())
                {
                    context.Customer.AddRange(
                        new Customer
                        {
                            //UserID = 7,
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
                            //UserID = 8,
                            FirstName = "Eva",
                            LastName = "Brown",
                            Email = "eva.brown@example.com",
                            PhoneNumber = "555-0202",
                            DateCreated = DateTime.UtcNow.AddMonths(-2),
                            PasswordHash = new string('b', 64),
                            Notes = "Allergic to certain products."
                        }
                    );
                    context.SaveChanges();
                }

            // Seed Services
            if (!context.Service.Any())
            {
                context.Service.AddRange(
            new Service {Name = "Haircut", Description = "Standard haircut service.", DurationMinutes = 30, BasePrice = 25.00m, Category = "Hair", IsActive = true },
            new Service {Name = "Full Color", Description = "Professional full-head color treatment.", DurationMinutes = 90, BasePrice = 120.00m, Category = "Color", IsActive = true },
            new Service {Name = "Blowout", Description = "Wash and professional blowout styling.", DurationMinutes = 45, BasePrice = 40.00m, Category = "Hair", IsActive = true },
            new Service {Name = "Men's Cut", Description = "Haircut and styling for men.", DurationMinutes = 25, BasePrice = 20.00m, Category = "Hair", IsActive = true },
            new Service {Name = "Deep Tissue Massage", Description = "60-minute deep tissue massage to relieve tension.", DurationMinutes = 60, BasePrice = 90.00m, Category = "Massage", IsActive = true },
            new Service {Name = "Swedish Massage", Description = "Relaxing 60-minute Swedish massage.", DurationMinutes = 60, BasePrice = 80.00m, Category = "Massage", IsActive = true },
            new Service {Name = "Hot Stone Massage", Description = "Heated stones to relax muscles during a 75-minute session.", DurationMinutes = 75, BasePrice = 110.00m, Category = "Massage", IsActive = true },
            new Service {Name = "Aromatherapy Massage", Description = "Massage using essential oils for relaxation.", DurationMinutes = 60, BasePrice = 95.00m, Category = "Massage", IsActive = true },
            new Service {Name = "Facial - Classic", Description = "Cleansing and rejuvenating facial treatment.", DurationMinutes = 50, BasePrice = 70.00m, Category = "Facial", IsActive = true },
            new Service {Name = "Facial - Anti-Aging", Description = "Advanced facial targeting fine lines and elasticity.", DurationMinutes = 70, BasePrice = 110.00m, Category = "Facial", IsActive = true },
            new Service {Name = "Microdermabrasion", Description = "Exfoliation treatment for smoother skin.", DurationMinutes = 45, BasePrice = 85.00m, Category = "Facial", IsActive = true },
            new Service {Name = "Express Facial", Description = "Quick 30-minute facial for a refreshed look.", DurationMinutes = 30, BasePrice = 45.00m, Category = "Facial", IsActive = true },
            new Service {Name = "Manicure", Description = "Standard manicure with polish.", DurationMinutes = 45, BasePrice = 30.00m, Category = "Nails", IsActive = true },
            new Service {Name = "Gel Manicure", Description = "Long-lasting gel manicure.", DurationMinutes = 60, BasePrice = 45.00m, Category = "Nails", IsActive = true },
            new Service {Name = "Pedicure", Description = "Relaxing pedicure with foot soak and scrub.", DurationMinutes = 50, BasePrice = 40.00m, Category = "Nails", IsActive = true },
            new Service {Name = "Gel Pedicure", Description = "Pedicure with gel polish.", DurationMinutes = 65, BasePrice = 55.00m, Category = "Nails", IsActive = true },
            new Service {Name = "Waxing - Eyebrows", Description = "Eyebrow shaping and waxing.", DurationMinutes = 15, BasePrice = 15.00m, Category = "Waxing", IsActive = true },
            new Service {Name = "Waxing - Full Leg", Description = "Full leg waxing treatment.", DurationMinutes = 40, BasePrice = 50.00m, Category = "Waxing", IsActive = true },
            new Service {Name = "Body Scrub", Description = "Full body exfoliation and polish.", DurationMinutes = 45, BasePrice = 70.00m, Category = "Body", IsActive = true },
            new Service {Name = "Couples Massage", Description = "Side-by-side massage for two.", DurationMinutes = 60, BasePrice = 180.00m, Category = "Massage", IsActive = true }

                );
                context.SaveChanges();
            }

            // Seed ServicePerformingEmployeeServices
            if (!context.ServicePerformingEmployeeService.Any())
            {
                context.ServicePerformingEmployeeService.AddRange(
            // Distribute services among multiple service-performing employees
            // Bob (EmployeeID = 2) handles a mix of hair and introductory services
            new ServicePerformingEmployeeService {EmployeeID = 2, ServiceID = 1 },
            new ServicePerformingEmployeeService { EmployeeID = 2, ServiceID = 2 },
            new ServicePerformingEmployeeService { EmployeeID = 2, ServiceID = 3 },
            new ServicePerformingEmployeeService {EmployeeID = 2, ServiceID = 4 },
            new ServicePerformingEmployeeService {EmployeeID = 2, ServiceID = 9 },

            // Dave (EmployeeID = 4) focuses on massages
            new ServicePerformingEmployeeService {EmployeeID = 4, ServiceID = 5 },
            new ServicePerformingEmployeeService { EmployeeID = 4, ServiceID = 6 },
            new ServicePerformingEmployeeService {EmployeeID = 4, ServiceID = 7 },
            new ServicePerformingEmployeeService {EmployeeID = 4, ServiceID = 8 },
            new ServicePerformingEmployeeService {EmployeeID = 4, ServiceID = 20 },

            // Emma (EmployeeID = 5) focuses on facials
            new ServicePerformingEmployeeService {EmployeeID = 5, ServiceID = 10 },
            new ServicePerformingEmployeeService { EmployeeID = 5, ServiceID = 11 },
            new ServicePerformingEmployeeService {EmployeeID = 5, ServiceID = 12 },
            new ServicePerformingEmployeeService {EmployeeID = 5, ServiceID = 9 },
            new ServicePerformingEmployeeService {EmployeeID = 5, ServiceID = 19 },

            // Fiona (EmployeeID = 6) focuses on nails and waxing
            new ServicePerformingEmployeeService {EmployeeID = 6, ServiceID = 13 },
            new ServicePerformingEmployeeService {EmployeeID = 6, ServiceID = 14 },
            new ServicePerformingEmployeeService {EmployeeID = 6, ServiceID = 15 },
            new ServicePerformingEmployeeService {EmployeeID = 6, ServiceID = 16 },
            new ServicePerformingEmployeeService {EmployeeID = 6, ServiceID = 17 },
            new ServicePerformingEmployeeService {EmployeeID = 6, ServiceID = 18 }
                );
                context.SaveChanges();
            }

            // Seed Appointments
            if (!context.Appointment.Any())
            {
                context.Appointment.AddRange(
                    new Appointment
                    {
                        //AppointmentID = 1,
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
                        //AppointmentID = 2,
                        EmployeeID = 2,
                        ServiceID = 2,
                        CustomerID = 2,
                        ScheduledDate = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(7)),
                        ScheduledTime = TimeOnly.Parse("13:00"),
                        Duration = 90,
                        Price = 120.00m
                    }
                );
                context.SaveChanges();
            }
        }
      

        //// Utility: get all seeded objects as enumerable
        //public static IEnumerable<object> All()
        //{
        //    foreach (var e in Employees) yield return e;
        //    foreach (var c in Customers) yield return c;
        //    foreach (var s in Services) yield return s;
        //    foreach (var sp in ServicePerformingEmployeeServices) yield return sp;
        //    foreach (var a in Appointments) yield return a;
        //}
    }
}
