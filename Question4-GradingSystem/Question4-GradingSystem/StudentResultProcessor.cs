namespace Question4_GradingSystem;

public class StudentResultProcessor
{
    public List<Student> ReadStudentsFromFile(string inputFilePath)
    {
        var students = new List<Student>();
        
        try
        {
            using var reader = new StreamReader(inputFilePath);
            string? line;
            int lineNumber = 0;
            
            while ((line = reader.ReadLine()) != null)
            {
                lineNumber++;
                try
                {
                    var fields = line.Split(',');
                    
                    if (fields.Length != 3)
                    {
                        throw new StudentMissingFieldException($"Line {lineNumber}: Expected 3 fields, got {fields.Length}");
                    }
                    
                    if (!int.TryParse(fields[0].Trim(), out int id))
                    {
                        throw new InvalidScoreFormatException($"Line {lineNumber}: Invalid ID format '{fields[0]}'");
                    }
                    
                    if (!int.TryParse(fields[2].Trim(), out int score))
                    {
                        throw new InvalidScoreFormatException($"Line {lineNumber}: Invalid score format '{fields[2]}'");
                    }
                    
                    var student = new Student(id, fields[1].Trim(), score);
                    students.Add(student);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing line {lineNumber}: {ex.Message}");
                }
            }
        }
        catch (FileNotFoundException)
        {
            throw new FileNotFoundException($"Input file '{inputFilePath}' not found");
        }
        
        return students;
    }

    public void WriteReportToFile(List<Student> students, string outputFilePath)
    {
        try
        {
            using var writer = new StreamWriter(outputFilePath);
            foreach (var student in students)
            {
                var grade = student.GetGrade();
                writer.WriteLine($"{student.FullName} (ID: {student.Id}): Score = {student.Score}, Grade = {grade}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error writing to output file: {ex.Message}");
        }
    }
}
