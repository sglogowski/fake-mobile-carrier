using DbUp;
using System;
using System.Reflection;

namespace FakeMobileCarrier.DbUp
{
    class Program
    {
        static int Main(string[] args)
        {
            const string connectionString = "Server=.; Database=FakeMobileCarrierDb; Integrated Security=True; Trusted_connection=true";

            EnsureDatabase.For
                .SqlDatabase(connectionString);

            var upgrader =
                DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .Build();

            var result = upgrader.PerformUpgrade();
            if (result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Success!");
                Console.ResetColor();

                return 0;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
#if DEBUG
                Console.ReadLine();
#endif
                return -1;
            }
        }
    }
}
