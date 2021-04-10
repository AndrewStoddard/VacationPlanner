// ***********************************************************************
// Author           : Incendy
// Created          : 04-07-2021
//
// Last Modified By : Incendy
// Last Modified On : 04-07-2021
// ***********************************************************************

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace AndrewStoddardVacationPlanner
{
    /// <summary>
    ///     Class Program.
    /// </summary>
    public class Program
    {
        #region Methods

        /// <summary>
        ///     Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        ///     Creates the host builder.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>IHostBuilder.</returns>
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                       .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        }

        #endregion
    }
}