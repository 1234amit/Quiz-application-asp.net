namespace Quiz_application.Models.Entities
{
    public class Question
    {
        public Guid Id { get; init; }
        public required string Text { get; init; }

        //options
        public required List<Option> Options { get; init; }
        public required Guid CorrectOption { get; init; }
    }
}
