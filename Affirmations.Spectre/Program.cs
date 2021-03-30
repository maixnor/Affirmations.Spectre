using System;
using System.Net.Http;
using System.Text.Json;
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
                    if (AnsiConsole.Confirm("Do you want to [bold red]quit[/] already?:sad_but_relieved_face:"))
                        return;
                    else 
                        continue;
                var jsonObject = JsonSerializer.Deserialize<Model>(_client.GetStringAsync("").Result);
                AnsiConsole.Render(new Markup($"[bold red]{jsonObject.affirmation}\n[/]"));
            }
        }
    }

    public struct Model
    {
        public string affirmation { get; set; }
    }
}