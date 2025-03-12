using Study.Core.Entities;
using Study.Core.Interface.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Study.Data.Repository
{
    public class TranscriptRepository : IRepository<Transcript>
    {
        readonly DataContext _datacontext;

        public TranscriptRepository(DataContext context)
        {
            _datacontext = context;
        }

        public List<Transcript> GetAll()
        {
            return _datacontext.TranscriptList.ToList();
        }

        public async Task<Transcript> AddAsync(Transcript transcript)
        {
            try
            {
                _datacontext.TranscriptList.Add(transcript);
                await _datacontext.SaveChangesAsync();
                return transcript;
            }
            catch
            {
                return null;
            }
        }

        public Transcript? GetById(int id)
        {
            return _datacontext.TranscriptList.Where(t => t.Id == id).FirstOrDefault();
        }

        public int GetIndexById(int id)
        {
            return _datacontext.TranscriptList.ToList().FindIndex(t => t.Id == id);
        }

        public async Task<Transcript> UpdateAsync(Transcript transcript, int id)
        {
            var existingTranscript = _datacontext.TranscriptList.FirstOrDefault(c => c.Id == id);
            if (existingTranscript == null) return null;



            existingTranscript.LessonId = transcript.LessonId;
            existingTranscript.TranscriptUrl = transcript.TranscriptUrl;
            existingTranscript.UpdateBy = transcript.UpdateBy;
            existingTranscript.UpdateAt = DateTime.Now;

            try
            {
               await _datacontext.SaveChangesAsync();
                return transcript;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var transcript = _datacontext.TranscriptList.FirstOrDefault(c => c.Id == id);
            if (transcript == null) return false;
            try
            {
                _datacontext.TranscriptList.Remove(transcript);
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