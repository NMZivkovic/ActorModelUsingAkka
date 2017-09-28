using Akka.Actor;
using BlogReportingActors.Messages;
using System;
using System.Collections.Generic;

namespace BlogReportingActors
{
    /// <summary>
    /// Actor hadeling rest of the users.
    /// </summary>
    public class UsersActor : ReceiveActor
    {
        private Dictionary<string, IActorRef> _users;

        public UsersActor()
        {
            _users = new Dictionary<string, IActorRef>();

            Receive<StartedReadingMessage>(message => ReceivedStartMessage(message));
            Receive<StopedReadingMessage>(message => ReceivedStopMessage(message));
        }

        private void ReceivedStartMessage(StartedReadingMessage message)
        {
            IActorRef userActor;

            if(!_users.TryGetValue(message.User, out userActor))
            {
                userActor = Context.ActorOf(Props.Create(typeof(UserActor)), message.User);
                _users.Add(message.User, userActor);
            }

            userActor.Tell(message);
        }

        private void ReceivedStopMessage(StopedReadingMessage message)
        {
            IActorRef userActor;

            if (!_users.TryGetValue(message.User, out userActor))
            {
                throw new InvalidOperationException("User doesn't exists!");
            }

            userActor.Tell(message);
        }
    }
}
