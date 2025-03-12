using AutoMapper;
using Study.Core.DTOs;
using Study.Core.Entities;
using Study.Core.Interface.IntarfaceService;
using Study.Core.Interface.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Study.Core.Interface.IntarfaceService.ITranscriptService;

namespace Study.Service
{
    
        public class TranscriptService :ITranscriptService
        {
            readonly IRepository<Transcript> _transcriptRepository;
            readonly IMapper _mapper;

            public TranscriptService(IRepository<Transcript> transcriptRepository, IMapper mapper)
            {
                _transcriptRepository = transcriptRepository;
                _mapper = mapper;
            }

            public IEnumerable<TranscriptDTO> GetAllTranscript()
            {
                var transcripts = _transcriptRepository.GetAll();
                return _mapper.Map<IEnumerable<TranscriptDTO>>(transcripts);
            }

            public TranscriptDTO GetTranscriptById(int id)
            {
                var transcript = _transcriptRepository.GetById(id);
                return _mapper.Map<TranscriptDTO>(transcript);
            }

            public async Task<TranscriptDTO> UpdateTranscriptAsync(int id, TranscriptDTO transcript)
            {
            
            if (id < 0)
                return null;
            var Transcript = _mapper.Map<Transcript>(transcript);
            var result =await _transcriptRepository.UpdateAsync(Transcript, id);
            return _mapper.Map<TranscriptDTO>(result);
        }

            public async Task<TranscriptDTO> AddTranscriptAsync(TranscriptDTO transcript)
            {
            var Transcript = _mapper.Map<Transcript>(transcript);
            if (_transcriptRepository.GetById(Transcript.Id) == null)
            {
                var createdTranscript =await _transcriptRepository.AddAsync(Transcript);
                return _mapper.Map<TranscriptDTO>(createdTranscript);
            }
            return null;
        }

            public async Task<bool> DeleteTranscriptAsync(int id)
            {
                
                if (id < 0) return false;

              await _transcriptRepository.DeleteAsync(id);
            return true;
            }
        }
    

}

