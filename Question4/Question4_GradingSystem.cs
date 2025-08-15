using System;
using System.Collections.Generic;
using System.IO;

// Question 4: Grading System

// a. Create Student class
public class Student
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public int Score { get; set; }

    public Student(int id, string fullName, int score)
    {
        Id = id;
        FullName = fullName;
        Score = score;
    }

    public string GetGrade()
    {
        if (Score >= 80 && Score <= 100)
            return "A";
        else if (Score >= 70 && Score <= 79)
            return "B";
        else if (Score >= 60 && Score <= 69)
            return "C";
        else if (Score >= 50 && Score <= 59)
            return "D";
        else
            return "F";
    }
}

// b. Define custom exception classes
public class InvalidScoreFormatException : Exception
{
    public InvalidScoreFormatException(string message) : base(message) { }
}

public class MissingFieldException : Exception
{
    public MissingFieldException(string message) : base(message) { }
}

// d. Create StudentResultProcessor class
public class StudentResultProcessor
{
    public List<Student> ReadStudentsFromFile(string inputFilePath)
    {
        var students = new List<Student>();
        int lineNumber = 0;

        using (var reader = new StreamReader(inputFilePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                lineNumber++;
                try
                {
                    // Split line by comma
                    var fields = line.Split(',');
                    
                    // Validate number of fields
                    if (fields.Length != 3)
                    {
                        throw new MissingFieldException($"Line {lineNumber}: Expected 3 fields, found {fields.Length}");
                    }

                    // Parse student ID
                    if (!int.TryParse(fields[0].Trim(), out int id))
                    {
                        throw new InvalidScoreFormatException($"Line {lineNumber}: Invalid student ID format '{fields[0]}'");
                    }

                    // Get full name
                    string fullName = fields[1].Trim();

                    // Parse score
                    if (!int.TryParse(fields[2].Trim(), out int score))
                    {
                        throw new InvalidScoreFormatException($"Line {lineNumber}: Invalid score format '{fields[2]}'");
                    }

                    // Validate score range
                    if (score < 0 || score > 100)
                    {
                        throw new InvalidScoreFormatException($"Line {lineNumber}: Score must be between 0 and 100, found {score}");
                    }

                    var student = new Student(id, fullName, score);
                    students.Add(student);
                }
                catch (MissingFieldException)
                {
                    throw; // Re-throw to be caught by main method
                }
                catch (InvalidScoreFormatException)
                {
                    throw; // Re-throw to be caught by main method
                }
                catch (Exception ex)
                {
                    throw new Exception($"Line {lineNumber}: Unexpected error - {ex.Message}");
                }
            }
        }

        return students;
    }

    public void WriteReportToFile(List<Student> students, string outputFilePath)
    {
        using (var writer = new StreamWriter(outputFilePath))
        {
            writer.WriteLine("=== Student Grade Report ===");
            writer.WriteLine($"Generated on: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            writer.WriteLine();

            foreach (var student in students)
            {
                string grade = student.GetGrade();
                writer.WriteLine($"{student.FullName} (ID: {student.Id}): Score = {student.Score}, Grade = {grade}");
            }

            writer.WriteLine();
            writer.WriteLine($"Total students processed: {students.Count}");
        }
    }
}

// Main application
class Program
{
    static void Main(string[] args)
    {
        string inputFilePath = "students.txt";
        string outputFilePath = "grade_report.txt";

        // Create sample input file
        CreateSampleInputFile(inputFilePath);

        var processor = new StudentResultProcessor();

        try
        {
            // Read students from file
            Console.WriteLine("Reading student data from file...");
            var students = processor.ReadStudentsFromFile(inputFilePath);
            Console.WriteLine($"Successfully read {students.Count} students from file.");

            // Write report to file
            Console.WriteLine("Generating grade report...");
            processor.WriteReportToFile(students, outputFilePath);
            Console.WriteLine($"Grade report written to {outputFilePath}");

            // Display summary
            Console.WriteLine("\n=== Summary ===");
            foreach (var student in students)
            {
                Console.WriteLine($"{student.FullName} (ID: {student.Id}): Score = {student.Score}, Grade = {student.GetGrade()}");
            }
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine($"Error: Input file not found - {ex.Message}");
        }
        catch (InvalidScoreFormatException ex)
        {
            Console.WriteLine($"Error: Invalid score format - {ex.Message}");
        }
        catch (MissingFieldException ex)
        {
            Console.WriteLine($"Error: Missing field in data - {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void CreateSampleInputFile(string filePath)
    {
        using (var writer = new StreamWriter(filePath))
        {
            writer.WriteLine("101,Alice Smith,84");
            writer.WriteLine("102,Bob Johnson,72");
            writer.WriteLine("103,Carol Davis,95");
            writer.WriteLine("104,David Wilson,68");
            writer.WriteLine("105,Eva Brown,45");
        }
        Console.WriteLine($"Sample input file created: {filePath}");
    }
} 