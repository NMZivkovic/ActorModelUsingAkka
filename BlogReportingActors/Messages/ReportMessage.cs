namespace BlogReportingActors.Messages
{
    /// <summary>
    /// Message containing reporting informations.
    /// </summary>
    public class ReportMessage : Message
    {
        public long Milliseconds { get; private set; }

        public ReportMessage(string user, string article, long milliseconds)
            : base (user, article)
        {
            Milliseconds = milliseconds;
        }
    }
}
