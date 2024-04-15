using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniTask.data.Repositories;
using Unitask.Infrastructure.Services;

namespace Uni_tasl.Injections
{
    
    public static class DataInjections
    {
        public static void InjectData(this IServiceCollection services) 
        {
            services.AddScoped<AdminsRepositories, AdminsRepositories>();
            services.AddScoped<BaseRepositories, BaseRepositories>();
            services.AddScoped<CandidatesRepositories, CandidatesRepositories>();
            services.AddScoped<ElectionsRepositories, ElectionsRepositories>();
            services.AddScoped<PartysRepositories, PartysRepositories>();
            services.AddScoped<RegionsRepositories, RegionsRepositories>();
            services.AddScoped<ResultsRepositories, ResultsRepositories>();
            services.AddScoped<UsersRepositories, UsersRepositories>();
            services.AddScoped<VotersRepositories, VotersRepositories>();
            services.AddScoped<VotesRepositories, VotesRepositories>();
            services.AddScoped<VotingSystemsRepositories, VotingSystemsRepositories>();
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
        }
    }
}
