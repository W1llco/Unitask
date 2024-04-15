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
            services.AddSingleton<VotingContext, VotingContext>(); //Come back to this

            services.AddSingleton(typeof(Form1));
            services.AddTransient(typeof(VerifyVoter));
            services.AddTransient(typeof(CreateCandidates));
            services.AddTransient(typeof(CreateElection));

            DataInjections.InjectData(services);
            
            _provider = services.BuildServiceProvider();

            ApplicationConfiguration.Initialize();
            Application.Run((Form1)_provider.GetService(serviceType: typeof(Form1)));
            
        }



    }
}