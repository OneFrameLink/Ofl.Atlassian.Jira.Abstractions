namespace Ofl.Atlassian.Jira.V2
{
    public class RemoteObject
    {
        public string Url { get; set; }

        public string Title { get; set; }

        public string Summary { get; set; }

        public Icon Icon { get; set; }

        public Status Status { get; set; }
    }
}
