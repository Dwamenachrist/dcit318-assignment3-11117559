using Question4_GradingSystem;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            var processor = new StudentResultProcessor();
            
            // Create sample input file
            var inputFile = "students.txt";
            var outputFile = "grades_report.txt";
            
            // Create sample data
            File.WriteAllText(inputFile, 
                "101,Alice Smith,84\n" +
                "102,Bob Johnson,72\n" +
                "103,Carol Davis,95\n" +
                "104,David Wilson,65\n" +
                "105,Eva Brown,88");
            
            Console.WriteLine("Sample input file created successfully");
            
            // Read and process students
            var students = processor.ReadStudentsFromFile(inputFile);
            Console.WriteLine($"Processed {students.Count} students");
            
            // Write report
            processor.WriteReportToFile(students, outputFile);
            Console.WriteLine($"Report written to {outputFile}");
            
            // Display results
            Console.WriteLine("\n=== Student Grades ===");
            foreach (var student in students)
            {
                Console.WriteLine($"{student.FullName}: Score = {student.Score}, Grade = {student.GetGrade()}");
            }
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine($"File error: {ex.Message}");
        }
        catch (InvalidScoreFormatException ex)
        {
            Console.WriteLine($"Score format error: {ex.Message}");
        }
        catch (StudentMissingFieldException ex)
        {
            Console.WriteLine($"Missing field error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
