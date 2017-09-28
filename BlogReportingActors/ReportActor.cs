using Akka.Actor;
using BlogReportingActors.Messages;
using System;
using System.Collections.Generic;

namespace BlogReportingActors
{
    /// <summary>
    /// Handles reporting part of the application.
    /// </summary>
    public class ReportActor : ReceiveActor
    {
        private Dictionary<string, long> _articleTimeSpent;
        private Dictionary<string, int> _articleViews;

        public ReportActor()
        {
            _articleTimeSpent = new Dictionary<string, long>();
            _articleViews = new Dictionary<string, int>();

            Receive<ReportMessage>(message => ReceivedReportMessage(message));
            Receive<StartedReadingMessage>(message => IncreaseViewCounter(message));
        }

        private void ReceivedReportMessage(ReportMessage message)
        {
            long time;
            if (_articleTimeSpent.TryGetValue(message.Article, out time))
                time += message.Milliseconds;
            else 
                _articleTimeSpent.Add(message.Article, message.Milliseconds);

            Console.WriteLine("******************************************************");
            Console.WriteLine("User {0} was reading article {1} for {2} milliseconds.", message.User, message.Article, message.Milliseconds);
            Console.WriteLine("Aricle {0} was read for {1} milliseconds in total.", message.Article, _articleTimeSpent[message.Article]);
            Console.WriteLine("******************************************************\n");         
        }

        private void IncreaseViewCounter(StartedReadingMessage message)
        {
            int count;
            if (_articleViews.TryGetValue(message.Article, out count))
                _articleViews[message.Article]++;
            else
                _articleViews.Add(message.Article, 1);

            Console.WriteLine("******************************************************");
            Console.WriteLine("Article {0} has {1} views", message.Article, _articleViews[message.Article]);
            Console.WriteLine("******************************************************\n");
        }
    }
}
