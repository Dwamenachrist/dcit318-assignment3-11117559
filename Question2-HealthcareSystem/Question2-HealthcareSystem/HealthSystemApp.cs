namespace Question2_HealthcareSystem;

public class HealthSystemApp
{
    private Repository<Patient> _patientRepo = new();
    private Repository<Prescription> _prescriptionRepo = new();
    private Dictionary<int, List<Prescription>> _prescriptionMap = new();

    public void SeedData()
    {
        // Add patients
        _patientRepo.Add(new Patient(1, "John Doe", 35, "Male"));
        _patientRepo.Add(new Patient(2, "Jane Smith", 28, "Female"));
        _patientRepo.Add(new Patient(3, "Bob Johnson", 45, "Male"));

        // Add prescriptions
        _prescriptionRepo.Add(new Prescription(1, 1, "Aspirin", DateTime.Now.AddDays(-5)));
        _prescriptionRepo.Add(new Prescription(2, 1, "Vitamin D", DateTime.Now.AddDays(-3)));
        _prescriptionRepo.Add(new Prescription(3, 2, "Ibuprofen", DateTime.Now.AddDays(-2)));
        _prescriptionRepo.Add(new Prescription(4, 2, "Calcium", DateTime.Now.AddDays(-1)));
        _prescriptionRepo.Add(new Prescription(5, 3, "Antibiotics", DateTime.Now));
    }

    public void BuildPrescriptionMap()
    {
        var prescriptions = _prescriptionRepo.GetAll();
        foreach (var prescription in prescriptions)
        {
            if (!_prescriptionMap.ContainsKey(prescription.PatientId))
            {
                _prescriptionMap[prescription.PatientId] = new List<Prescription>();
            }
            _prescriptionMap[prescription.PatientId].Add(prescription);
        }
    }

    public void PrintAllPatients()
    {
        Console.WriteLine("=== All Patients ===");
        var patients = _patientRepo.GetAll();
        foreach (var patient in patients)
        {
            Console.WriteLine($"ID: {patient.Id}, Name: {patient.Name}, Age: {patient.Age}, Gender: {patient.Gender}");
        }
        Console.WriteLine();
    }

    public void PrintPrescriptionsForPatient(int id)
    {
        if (_prescriptionMap.ContainsKey(id))
        {
            Console.WriteLine($"=== Prescriptions for Patient ID {id} ===");
            var prescriptions = _prescriptionMap[id];
            foreach (var prescription in prescriptions)
            {
                Console.WriteLine($"Medication: {prescription.MedicationName}, Date: {prescription.DateIssued:yyyy-MM-dd}");
            }
        }
        else
        {
            Console.WriteLine($"No prescriptions found for Patient ID {id}");
        }
        Console.WriteLine();
    }
}
