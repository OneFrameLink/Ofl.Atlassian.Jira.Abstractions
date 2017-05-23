using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Ofl.Atlassian.Jira.V2
{
    public interface ICredentialProvider
    {
        Task<HttpMessageHandler> CreateHttpMessageHandler(CancellationToken cancellationToken);
    }
}
