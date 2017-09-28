namespace BlogReportingActors.Messages
{
    /// <summary>
    ///  Message indicating that user has stopped reading.
    /// </summary>
    class StopedReadingMessage : Message
    {
        public StopedReadingMessage(string user, string article)
            : base (user, article) {}
    }
}
