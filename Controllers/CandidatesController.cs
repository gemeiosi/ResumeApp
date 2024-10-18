using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResumeApp.Data;
using ResumeApp.Data.Interfaces;
using ResumeApp.Data.Dtos;
using AutoMapper;
using ResumeApp.Data.Models;

namespace ResumeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly ICandidateService _service;
        private readonly IMapper _mapper;

        public CandidatesController(ICandidateService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/Candidates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CandidateDto>>> Getcandidate()
        {
            var allCandidates = await _service.GetAllCandidates();
            return Ok(allCandidates);
        }

        // GET: api/Candidates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CandidateDto>> GetCandidate(int id)
        {
            var candidate = await _service.GetCandidateById(id);
            
            if (candidate == null)
            {
                return NotFound();
            }
            CandidateDto response = _mapper.Map<CandidateDto>(candidate);

            return response;
        }

        // PUT: api/Candidates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCandidate(int id, CandidateDto candidate)
        {
            if (id != candidate.Id)
            {
                return BadRequest();
            }
            var entity = _mapper.Map<Candidate>(candidate);
            await _service.UpdateCandidate(id, entity);

            return NoContent();
        }

        // POST: api/Candidates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CandidateDto>> PostCandidate(CandidateDto candidate)
        {
            var entity = _mapper.Map<Candidate>(candidate);
            var success = await _service.AddCandidate(entity);
            if (!success)
            {
                return BadRequest("Candidate Exists");
            }
            return Ok(candidate);
        }

        // DELETE: api/Candidates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCandidate(int id)
        {
            var success = await _service.DeleteCandidate(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        
    }
}
