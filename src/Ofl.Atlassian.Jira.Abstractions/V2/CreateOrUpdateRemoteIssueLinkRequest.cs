namespace Ofl.Atlassian.Jira.V2
{
    public class CreateOrUpdateRemoteIssueLinkRequest
    {
        public string IssueIdOrKey { get; set; }

        public RemoteIssueLink RemoteIssueLink { get; set; }
    }
}
