using System.Collections.Generic;

namespace _213FinalProject.Models
{
    public static class AppointmentStore
    {
        // start from seed appointments
        private static readonly List<Appointment> _appointments = new List<Appointment>(SeedData.Appointments ?? new List<Appointment>());

        public static IReadOnlyList<Appointment> Appointments => _appointments.AsReadOnly();

        public static int GetNextId() => _appointments.Count == 0 ? 1 : (_appointments[^1].AppointmentID + 1);

        public static void Add(Appointment appointment)
        {
            _appointments.Add(appointment);
        }
    }
}
