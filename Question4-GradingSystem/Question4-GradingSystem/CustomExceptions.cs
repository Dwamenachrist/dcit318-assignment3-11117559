namespace Question4_GradingSystem;

public class InvalidScoreFormatException : Exception
{
    public InvalidScoreFormatException(string message) : base(message) { }
}

public class StudentMissingFieldException : Exception
{
    public StudentMissingFieldException(string message) : base(message) { }
}
