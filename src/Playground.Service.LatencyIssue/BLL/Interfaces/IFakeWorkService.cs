using System.Threading;
using System.Threading.Tasks;
using Playground.Service.LatencyIssue.BLL.Services;

namespace Playground.Service.LatencyIssue.BLL.Interfaces;

public interface IFakeWorkService
{
    void InitData();

    Task<User> GetUser(long id, CancellationToken token);
}
