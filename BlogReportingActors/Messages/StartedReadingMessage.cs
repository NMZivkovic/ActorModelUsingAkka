namespace BlogReportingActors.Messages
{
    /// <summary>
    /// Message indicating that user has started reading.
    /// </summary>
    public class StartedReadingMessage : Message
    {
        public StartedReadingMessage(string user, string article)
            : base(user, article) {}
    }
}
