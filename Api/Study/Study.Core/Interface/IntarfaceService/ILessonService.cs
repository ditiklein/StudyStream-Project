using Study.Core.DTOs;
using Study.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Core.Interface.IntarfaceService
{
    public interface ILessonService
    {
        IEnumerable<LessonDTO> GetAllLessons();
        LessonDTO GetLessonById(int id);
        Task<LessonDTO> UpdateLessonAsync(int id, LessonDTO lesson);
        Task<LessonDTO> AddLessonAsync(LessonDTO lesson);
        Task<bool> DeleteLessonAsync(int id);
        

    }
}
