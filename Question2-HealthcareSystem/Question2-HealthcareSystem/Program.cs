using Question2_HealthcareSystem;

var app = new HealthSystemApp();
app.SeedData();
app.BuildPrescriptionMap();
app.PrintAllPatients();
app.PrintPrescriptionsForPatient(1);
app.PrintPrescriptionsForPatient(2);

Console.WriteLine("Press any key to exit...");
Console.ReadKey();
