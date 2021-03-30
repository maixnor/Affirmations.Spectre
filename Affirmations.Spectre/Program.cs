using System;
using System.Net.Http;
using Spectre.Console;

namespace Affirmations.Spectre
{
    class Program
    {
        private readonly HttpClient _client;
        static void Main(string[] args)
        {
            var p = new Program();
        }

        public Program()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("https://www.affirmations.dev/")
            };
            while (true)
            {
                if (!AnsiConsole.Confirm("Need some [bold green]Affirmation[/]?"))
                    if (AnsiConsole.Confirm("Do you want to [bold red]quit[/]:sad_but_relieved_face:"))
                        return;
                    else 
                        continue;
                var jsonResponse = _client.GetStringAsync("").Result;
                AnsiConsole.Render(new Markup($"[bold red]{jsonResponse}\n[/]"));
            }
        }
    }
}