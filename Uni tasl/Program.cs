using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Uni_tasl.Injections;
using Unitask.Infrastructure.Services;
using UniTask.data;
using UniTask.data.Repositories;

namespace Uni_tasl
{
    // The Program class acts as the entry point for the application, setting up services and launching the main form.
    public class Program
    {
        // Static property to hold the service provider that will manage dependency injection throughout the application.
        public static IServiceProvider _provider { get; set; }

        // STAThreadAttribute indicates that the COM threading model for the application is single-threaded apartment, which is a common setting for Windows Forms apps.
        [STAThread]
        public static void Main()
        {
            // Setting up dependency injection using Microsoft.Extensions.DependencyInjection.
            ServiceCollection services = new ServiceCollection();

            // Add the VotingContext as a singleton, meaning one instance is used throughout the application's lifetime.
            services.AddSingleton<VotingContext, VotingContext>();

            // Registering forms with appropriate lifetimes:
            // Singleton for Form1, which acts as the main form and should maintain state throughout the application's lifecycle.
            services.AddSingleton(typeof(Form1));

            // Transient services for other forms, ensuring a new instance is created each time the service is requested.
            services.AddTransient(typeof(ExternalVoterLogin));
            services.AddTransient(typeof(InternalVoterLogin));
            services.AddTransient(typeof(SelectElection));
            services.AddTransient(typeof(VoterPage));
            services.AddTransient(typeof(AdminLogin));
            services.AddTransient(typeof(AdminDashboard));
            services.AddTransient(typeof(CreateCandidates));
            services.AddTransient(typeof(CreateElection));
            services.AddTransient(typeof(ModifyElection));
            services.AddTransient(typeof(VerifyVoter));
            services.AddTransient(typeof(CreateVoter));

            // InjectData is contained within the DataInjections class, responsible for configuring additional services and repositories.
            DataInjections.InjectData(services);

            // Building the service provider from the configured services collection.
            _provider = services.BuildServiceProvider();

            // ApplicationConfiguration.Initialize is used to set up application-wide settings such as high DPI settings or visual styles in Windows Forms.
            ApplicationConfiguration.Initialize();

            // Starting the application by running the main form, retrieved from the service provider, ensuring it uses the configured dependencies.
            Application.Run((Form1)_provider.GetService(typeof(Form1)));
        }
    }

}