using Microsoft.AspNetCore.Mvc.Rendering;

namespace Quiz_application.Models.viewmodels
{
    public class QuizViewModel
    {
        public required List<QuestionItem> Questions { get; set; }
    }

    public class QuestionItem
    {
        public Guid QuestionId { get; set; }
        public required string Text { get; set; }
        public required List<SelectListItem> Options { get; set; }
    }
}
