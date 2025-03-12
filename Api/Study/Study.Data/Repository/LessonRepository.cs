
using Study.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Study.Core.Interface.InterfaceRepository;
using System.Threading.Tasks;

namespace Study.Data.Repository
{
    public class LessonRepository : IRepository<Lesson>
    {
        readonly DataContext _datacontext;

        public LessonRepository(DataContext context)
        {
            _datacontext = context;
        }

        public List<Lesson> GetAll()
        {
            return _datacontext.LessonList.ToList();
        }

        public async Task<Lesson> AddAsync(Lesson lesson)
        {
            try
            {
                _datacontext.LessonList.Add(lesson);
                 await _datacontext.SaveChangesAsync();
                return lesson;
            }
            catch
            {
                return null;
            }
        }

        public Lesson? GetById(int id)
        {
            return _datacontext.LessonList.Where(l => l.Id == id).FirstOrDefault();
        }

        public int GetIndexById(int id)
        {
            return _datacontext.LessonList.ToList().FindIndex(l => l.Id == id);
        }

        public async Task<Lesson> UpdateAsync(Lesson lesson, int id)
        {
            var existingLesson = _datacontext.LessonList.FirstOrDefault(c => c.Id == id);
            if (existingLesson == null) return null;


            existingLesson.UserId = lesson.UserId;
            existingLesson.Title = lesson.Title;
            existingLesson.Description = lesson.Description;
            existingLesson.LessonUrl = lesson.LessonUrl;
            existingLesson.CategoryId = lesson.CategoryId;
            existingLesson.UpdatedBy = lesson.UpdatedBy;
            existingLesson.UpdatedAt = DateTime.Now;

            try
            {
                await _datacontext.SaveChangesAsync();
                return lesson;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var lesson = _datacontext.LessonList.FirstOrDefault(c => c.Id == id);
            if (lesson == null) return false;
            try
            {
                _datacontext.LessonList.Remove(lesson);
                await _datacontext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
