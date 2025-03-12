using Study.Core.DTOs;
using Study.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Study.Core.Interface.IntarfaceService
{
    
        public interface ITranscriptService
        {
            IEnumerable<TranscriptDTO> GetAllTranscript();
            TranscriptDTO GetTranscriptById(int id);
        Task<TranscriptDTO> UpdateTranscriptAsync(int id, TranscriptDTO transcript);
        Task<TranscriptDTO> AddTranscriptAsync(TranscriptDTO transcript);
        Task<bool> DeleteTranscriptAsync(int id);
        }

    
}
