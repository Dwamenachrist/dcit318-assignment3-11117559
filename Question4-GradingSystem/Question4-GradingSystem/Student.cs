namespace Question4_GradingSystem;

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
        return Score switch
        {
            >= 80 and <= 100 => "A",
            >= 70 and < 80 => "B",
            >= 60 and < 70 => "C",
            >= 50 and < 60 => "D",
            _ => "F"
        };
    }
}
