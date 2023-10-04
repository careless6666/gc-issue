using System.Threading;
using System.Threading.Tasks;
using Aer.Playground.Service.LatencyIssue.BLL.Services;

namespace Aer.Playground.Service.LatencyIssue.BLL.Interfaces;

public interface IFakeWorkService
{
    void InitData();

    Task<User> GetUser(long id, CancellationToken token);
}
