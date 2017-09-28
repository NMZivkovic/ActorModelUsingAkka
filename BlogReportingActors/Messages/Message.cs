namespace BlogReportingActors.Messages
{
    /// <summary>
    /// Abstraction of all messages.
    /// </summary>
    public abstract class Message
    {
        public string User { get; private set; }
        public string Article { get; private set; }

        public Message(string user, string article)
        {
            User = user;
            Article = article;
        }
    }
}
