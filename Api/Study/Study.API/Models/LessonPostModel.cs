using System.ComponentModel.DataAnnotations;

namespace Study.API.Models
{
    public class LessonPostModel
    {
        public int UserId { get; set; }  // מזהה המשתמש שיצר את השיעור

        public string ?Title { get; set; }  // כותרת השיעור

        public string? Description { get; set; }  // תיאור השיעור

        public string? LessonUrl { get; set; }  // קישור לשיעור

        public int CategoryId { get; set; }  // מזהה הקטגוריה של השיעור

    }
}
