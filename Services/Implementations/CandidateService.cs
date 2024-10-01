using JobCandidate.Data;
using JobCandidate.Services.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Data;
using JobCandidate.Models;

namespace JobCandidate.Services.Implementations
{
    public class CandidateService : ICandidate
    {

        private readonly SigmaCandidateDBContext _context;

        public CandidateService(SigmaCandidateDBContext context)
        {
            _context = context;
        }

        public Task<CandidateModel> AddUpdateCandidateAsync(string FirstName)
        {
            var command = _context.Database.GetDbConnection().CreateCommand();

            return null;
        }

      

    }
}
