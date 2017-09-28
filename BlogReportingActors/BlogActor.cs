using Akka.Actor;
using BlogReportingActors.Messages;

namespace BlogReportingActors
{
    /// <summary>
    /// Highest level actor.
    /// Containing rest of the actors.
    /// </summary>
    public class BlogActor : ReceiveActor
    {
        private IActorRef _users;
        private IActorRef _reporting;

        public BlogActor()
        {
            _users = Context.ActorOf(Props.Create(typeof(UsersActor)), "users");
            _reporting = Context.ActorOf(Props.Create(typeof(ReportActor)), "reporting");

            Receive<Message>(message => {
                _users.Forward(message);
                _reporting.Forward(message);
            });
        }
    }
}
