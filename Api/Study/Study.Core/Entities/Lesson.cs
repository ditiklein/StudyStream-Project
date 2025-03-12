using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Core.Entities
{
    [Table("Lessons")]
    public class Lesson
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]

        public User? User { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? LessonUrl { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]

        public Category? Category { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Transcript? Transcript { get; set; }
    }
}
