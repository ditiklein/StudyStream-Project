using AutoMapper;
using Study.Core.DTOs;
using Study.Core.Entities;
using Study.Core.Interface.IntarfaceService;
using Study.Core.Interface.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Study.Services
{
    public class LessonService : ILessonService
    {
        readonly IRepository<Lesson> _lessonRepository;
        readonly IMapper _mapper;

        public LessonService(IRepository<Lesson> lessonRepository, IMapper mapper)
        {
            _lessonRepository = lessonRepository;
            _mapper = mapper;
        }

        public IEnumerable<LessonDTO> GetAllLessons()
        {
            var lessons = _lessonRepository.GetAll();
            return _mapper.Map<IEnumerable<LessonDTO>>(lessons);
        }

        public LessonDTO GetLessonById(int id)
        {
            var lesson = _lessonRepository.GetById(id);
            return _mapper.Map<LessonDTO>(lesson);
        }

        public async Task<LessonDTO> UpdateLessonAsync(int id, LessonDTO lesson)
        {
            var Lesson = _mapper.Map<Lesson>(lesson);
            var result =await _lessonRepository.UpdateAsync(Lesson, id);
            return _mapper.Map<LessonDTO>(result);
        }

        public async Task<LessonDTO> AddLessonAsync(LessonDTO lesson)
        {
            var Lesson = _mapper.Map<Lesson>(lesson);
            if (_lessonRepository.GetById(lesson.Id) == null)
            {
                var createdLesson =await _lessonRepository.AddAsync(Lesson);
                return _mapper.Map<LessonDTO>(createdLesson);
            }
            return null;
        }

        public async Task<bool> DeleteLessonAsync(int id)
        {
            await _lessonRepository.DeleteAsync(id);
            return true;
        }
    }
}
