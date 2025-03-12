using Study.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Core.DTOs
{
    public class LessonDTO
    {
        
        public int Id { get; set; }

        public int UserId { get; set; }

       

        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? LessonUrl { get; set; }

        public int CategoryId { get; set; }

        

        public int CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
