namespace Ofl.Atlassian.Jira.V2
{
    // NOTE: Incomplete.
    public class Comment
    {
        public string? Id { get; set; }

        public User? Author { get; set; }

        public string? Body { get; set; }

        public string? RenderedBody { get; set; }

        public User? UpdateAuthor { get; set; }

        public string? Created { get; set; }

        public string? Updated { get; set; }
    }
}
