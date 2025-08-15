using System;
using System.Collections.Generic;
using System.Linq;

// Question 2: Healthcare System

// a. Create a generic repository for entity management
public class Repository<T>
{
    private List<T> items = new List<T>();

    public void Add(T item)
    {
        items.Add(item);
    }

    public List<T> GetAll()
    {
        return new List<T>(items);
    }

    public T? GetById(Func<T, bool> predicate)
    {
        return items.FirstOrDefault(predicate);
    }

    public bool Remove(Func<T, bool> predicate)
    {
        var item = items.FirstOrDefault(predicate);
        if (item != null)
        {
            return items.Remove(item);
        }
        return false;
    }
}

// b. Define the Patient class
public class Patient
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }

    public Patient(int id, string name, int age, string gender)
    {
        Id = id;
        Name = name;
        Age = age;
        Gender = gender;
    }

    public override string ToString()
    {
        return $"Patient ID: {Id}, Name: {Name}, Age: {Age}, Gender: {Gender}";
    }
}

// c. Define the Prescription class
public class Prescription
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public string MedicationName { get; set; }
    public DateTime DateIssued { get; set; }

    public Prescription(int id, int patientId, string medicationName, DateTime dateIssued)
    {
        Id = id;
        PatientId = patientId;
        MedicationName = medicationName;
        DateIssued = dateIssued;
    }

    public override string ToString()
    {
        return $"Prescription ID: {Id}, Patient ID: {PatientId}, Medication: {MedicationName}, Date: {DateIssued:yyyy-MM-dd}";
    }
}

// g. Create HealthSystemApp class
public class HealthSystemApp
{
    private Repository<Patient> _patientRepo;
    private Repository<Prescription> _prescriptionRepo;
    private Dictionary<int, List<Prescription>> _prescriptionMap;

    public HealthSystemApp()
    {
        _patientRepo = new Repository<Patient>();
        _prescriptionRepo = new Repository<Prescription>();
        _prescriptionMap = new Dictionary<int, List<Prescription>>();
    }

    public void SeedData()
    {
        // Add 2-3 Patient objects
        _patientRepo.Add(new Patient(1, "John Doe", 35, "Male"));
        _patientRepo.Add(new Patient(2, "Jane Smith", 28, "Female"));
        _patientRepo.Add(new Patient(3, "Bob Johnson", 45, "Male"));

        // Add 4-5 Prescription objects
        _prescriptionRepo.Add(new Prescription(1, 1, "Aspirin", DateTime.Now.AddDays(-10)));
        _prescriptionRepo.Add(new Prescription(2, 1, "Ibuprofen", DateTime.Now.AddDays(-5)));
        _prescriptionRepo.Add(new Prescription(3, 2, "Amoxicillin", DateTime.Now.AddDays(-15)));
        _prescriptionRepo.Add(new Prescription(4, 2, "Vitamin D", DateTime.Now.AddDays(-3)));
        _prescriptionRepo.Add(new Prescription(5, 3, "Metformin", DateTime.Now.AddDays(-20)));
    }

    public void BuildPrescriptionMap()
    {
        var allPrescriptions = _prescriptionRepo.GetAll();
        _prescriptionMap = allPrescriptions
            .GroupBy(p => p.PatientId)
            .ToDictionary(g => g.Key, g => g.ToList());
    }

    public void PrintAllPatients()
    {
        Console.WriteLine("=== All Patients ===");
        var patients = _patientRepo.GetAll();
        foreach (var patient in patients)
        {
            Console.WriteLine(patient);
        }
        Console.WriteLine();
    }

    public void PrintPrescriptionsForPatient(int patientId)
    {
        Console.WriteLine($"=== Prescriptions for Patient ID: {patientId} ===");
        var prescriptions = GetPrescriptionsByPatientId(patientId);
        
        if (prescriptions.Count == 0)
        {
            Console.WriteLine("No prescriptions found for this patient.");
        }
        else
        {
            foreach (var prescription in prescriptions)
            {
                Console.WriteLine(prescription);
            }
        }
        Console.WriteLine();
    }

    public List<Prescription> GetPrescriptionsByPatientId(int patientId)
    {
        if (_prescriptionMap.ContainsKey(patientId))
        {
            return _prescriptionMap[patientId];
        }
        return new List<Prescription>();
    }
}

// Main application
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Healthcare System ===");
        
        var healthApp = new HealthSystemApp();
        
        // Seed data
        healthApp.SeedData();
        
        // Build prescription map
        healthApp.BuildPrescriptionMap();
        
        // Print all patients
        healthApp.PrintAllPatients();
        
        // Display prescriptions for a specific patient
        healthApp.PrintPrescriptionsForPatient(1);
        healthApp.PrintPrescriptionsForPatient(2);
        healthApp.PrintPrescriptionsForPatient(3);
    }
} 