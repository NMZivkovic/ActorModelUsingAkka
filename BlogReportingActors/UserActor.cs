using Akka.Actor;
using BlogReportingActors.Messages;
using System;
using System.Diagnostics;

namespace BlogReportingActors
{
    /// <summary>
    /// Actor handeling each individual user of the blog.
    /// </summary>
    public class UserActor : ReceiveActor
    {
        private Stopwatch _stopwatch;
        private bool _isAlreadyReading;

        public UserActor()
        {
            _stopwatch = new Stopwatch();
            Receive<StartedReadingMessage>(message => ReceivedStartMessage(message));
            Receive<StopedReadingMessage>(message => ReceivedStopMessage(message));
        }

        private void ReceivedStartMessage(StartedReadingMessage message)
        {
            if (_isAlreadyReading)
                throw new InvalidOperationException("User is already reading another article!");

            _stopwatch.Start();
            _isAlreadyReading = true;
        }

        private void ReceivedStopMessage(StopedReadingMessage message)
        {
            if (!_isAlreadyReading)
                throw new InvalidOperationException("User was not reading any article!");

            _stopwatch.Stop();
            _isAlreadyReading = false;

            Context.ActorSelection("../../reporting").Tell(new ReportMessage(message.User, message.Article, _stopwatch.ElapsedMilliseconds));

            _stopwatch.Reset();
        }
    }
}
