namespace Quiz_application.Models.Entities
{
    public class Option
    {
        public Guid Id { get; init; }
        public required string Text { get; init; }
        //relationship
        public Guid QuistionId { get; init; }
    }
}
