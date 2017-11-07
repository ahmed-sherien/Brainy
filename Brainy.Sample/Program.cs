using Brainy.PersonalAssistant;
using System;

namespace Brainy.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var brainBuilder = BrainBuilder.CreateBrain();
            brainBuilder.AddSensor<ConsoleSensor>();
            brainBuilder.AddPresenter<ConsolePresenter>();
            brainBuilder.AddSkill<GreetingSkill>();
            brainBuilder.AddSkill<PersonalAssistantSkill>();
            var brain = brainBuilder.Build();

            Console.WriteLine("Welcome to Brainy!");
            Console.WriteLine("==================");
            var exit = false;
            brain.Stopped += (sender, e) => exit = true;
            while (!exit)
            {
                Console.WriteLine("Hi, please give me an order:");
                Console.WriteLine("note: <order> [<parameter>]* [-<option> <option_parameter>]*");
                brain.Run();
            }
            Console.WriteLine("Press <Enter> to exit.");
            Console.ReadLine();
        }
    }
}
