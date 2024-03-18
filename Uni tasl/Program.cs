using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Uni_tasl.Injections;
using UniTask.data;

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
            Application.Run((Form1)_provider.GetService(typeof(Form1)));
        }

        

    }
}