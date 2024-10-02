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

        public async Task<CandidateModel> AddUpdateCandidateAsync(CandidateModel model)
        {
            var command = _context.Database.GetDbConnection().CreateCommand();

            var parameters = new[]
           {
                new SqlParameter("@Action", "CREATE"),
                new SqlParameter("@FirstName", model.FirstName),
                new SqlParameter("@LastName", model.LastName),
                new SqlParameter("@PhoneNumber", model.PhoneNumber),
                new SqlParameter("@Email", model.Email),
                new SqlParameter("@TimeInterval", model.TimeInterval),
                new SqlParameter("@LinkedInURL", model.LinkedInURL),
                new SqlParameter("@GitHubURL", model.GitHubURL),
                new SqlParameter("@Comment", model.Comment)
            };

            command.CommandText = "ManageCandidate";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(parameters);
            if (command.Connection.State != ConnectionState.Open)
            {
                await command.Connection.OpenAsync();
            }
            int affectedRows = await command.ExecuteNonQueryAsync();
            if (affectedRows > 0)
            {
                return model;
            }
            else
                return null;
        }

    }
}
