using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Uni_tasl.Injections;
using Unitask.Infrastructure.Services;
using UniTask.data;
using UniTask.data.Repositories;

namespace Uni_tasl
{
    public class Program
    {
        public static IServiceProvider _provider { get; set; }

        [STAThread]
        public static void Main()
        {
            // seting up dependency injection
            ServiceCollection services = new ServiceCollection();
            services.AddScoped<VotingContext, VotingContext>();

            services.AddSingleton(typeof(Form1));

            DataInjections.InjectData(services);
            
            _provider = services.BuildServiceProvider();

            ApplicationConfiguration.Initialize();
            Application.Run((Form1)_provider.GetService(serviceType: typeof(Form1)));
            services.AddScoped<AdminsRepositories>();
            services.AddScoped<BaseRepositories>();
            services.AddScoped<CandidatesRepositories>();
            services.AddScoped<ElectionsRepositories>();
            services.AddScoped<PartysRepositories>();
            services.AddScoped<RegionsRepositories>();
            services.AddScoped<ResultsRepositories>();
            services.AddScoped<UsersRepositories>();
            services.AddScoped<VotersRepositories>();
            services.AddScoped<VotesRepositories>();
            services.AddScoped<VotingSystemsRepositories>();
            services.AddScoped<AdminService>();
            services.AddScoped<CandidateService>();
            services.AddScoped<ElectionService>();
            services.AddScoped<PartyService>();
            services.AddScoped<RegionService>();
            services.AddScoped<ResultService>();
            services.AddScoped<UserService>();
            services.AddScoped<VoterService>();
            services.AddScoped<VoteService>();
            services.AddScoped<VotingSystemService>();
        }



    }
}