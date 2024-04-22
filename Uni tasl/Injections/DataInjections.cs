using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniTask.data.Repositories;
using Unitask.Infrastructure.Services;
using Uni_tasl.Helpers;
using static System.Formats.Asn1.AsnWriter;

namespace Uni_tasl.Injections
{
    public static class DataInjections
    {
        // Static method to configure dependency injection for repository and service classes
        // IServiceCollection extension method to add scoped services to the DI container
        public static void InjectData(this IServiceCollection services) 
        {
            // Adds a scoped lifetime to the AdminsRepositories. Scoped lifetime services are created once per client request.
            services.AddScoped<AdminsRepositories, AdminsRepositories>();
            services.AddScoped<CandidatesRepositories, CandidatesRepositories>();
            services.AddScoped<ElectionsRepositories, ElectionsRepositories>();
            services.AddScoped<PartysRepositories, PartysRepositories>();
            services.AddScoped<RegionsRepositories, RegionsRepositories>();
            services.AddScoped<ResultsRepositories, ResultsRepositories>();
            services.AddScoped<UsersRepositories, UsersRepositories>();
            services.AddScoped<VotersRepositories, VotersRepositories>();
            services.AddScoped<VotesRepositories, VotesRepositories>();
            services.AddScoped<VotingSystemsRepositories, VotingSystemsRepositories>();
            // Adds a scoped lifetime to the AdminService which might depend on AdminsRepositories
            services.AddScoped<AdminService, AdminService>();
            services.AddScoped<CandidateService, CandidateService>();
            services.AddScoped<ElectionService, ElectionService>();
            services.AddScoped<PartyService, PartyService>();
            services.AddScoped<RegionService, RegionService>();
            services.AddScoped<ResultService, ResultService>();
            services.AddScoped<UserService, UserService>();
            services.AddScoped<VoterService, VoterService>();
            services.AddScoped<VoteService, VoteService>();
            services.AddScoped<VotingSystemService, VotingSystemService>();
            services.AddScoped<HelperFunctions, HelperFunctions>();
        }
    }
}
