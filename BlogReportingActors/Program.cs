using Akka.Actor;
using BlogReportingActors.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlogReportingActors
{
    class Program
    {
        static void Main(string[] args)
        {
            ActorSystem system = ActorSystem.Create("rubikscode");

            IActorRef blogActor = system.ActorOf(Props.Create(typeof(BlogActor)), "blog");

            blogActor.Tell(new StartedReadingMessage("NapoleonHill", "Tuples in .NET world and C# 7.0 improvements"));
            
            // Used for simulation pourposes.
            Thread.Sleep(1000);

            blogActor.Tell(new StartedReadingMessage("VictorPelevin", "How to use “Art of War” to be better Software Craftsman"));

            // Used for simulation pourposes.
            Thread.Sleep(1000);

            blogActor.Tell(new StopedReadingMessage("NapoleonHill", "Tuples in .NET world and C# 7.0 improvements"));

            // Used for simulation pourposes.
            Thread.Sleep(500);

            blogActor.Tell(new StopedReadingMessage("VictorPelevin", "How to use “Art of War” to be better Software Craftsman"));

            Console.ReadLine();
        }
    }
}
