using Scheduler.Models;
using System.Linq;

namespace Scheduler.Services
{
    class PatientService
    {
        public static Patient GetPatientByDoctor(Doctor doctor, int patientId)
        {
            return doctor.Patients.FirstOrDefault(p => p.Id == patientId);
        }
    }
}
