using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Primitives;
using Playground.Service.LatencyIssue.BLL.Interfaces;

namespace Playground.Service.LatencyIssue.BLL.Services;

public class FakeWorkService: IFakeWorkService
{
    private readonly Dictionary<long, User> _users = new();
    private string longStr1;
    private string longStr2;
    private string longStr3;

    public void InitData()
    {
        for (var i = 0; i < 100_001; i++)
        {
            _users[i] = new User
            {
                Id = i,
                Name = $"my_name_{Guid.NewGuid()}",
                Info = new AdditionalInfo
                {
                    Id = Guid.NewGuid(),
                    Status = $"fake_status_{Guid.NewGuid()}"
                }
            };
        }

        longStr1 = GetLohString();
        longStr2 = GetLohString();
        longStr3 = GetLohString();
    }

    private string GetLohString()
    {
        var sb = new StringBuilder();

        sb.Append("Fake long");

        for (var i = 0; i < 1000; i++)
        {
            sb.Append(Guid.NewGuid().ToString());
        }

        return sb.ToString();
    }

    public async Task<User> GetUser(long id, CancellationToken token)
    {
        var user = _users.GetValueOrDefault(id);
        if (id % 2 == 0)
        {
            user.Info.Status = longStr1 + longStr2 + longStr3;
        }
        await Task.Delay(10 + Random.Shared.Next(100), token);
        return user;
    }
}

public class User
{
    public long Id { get; set; }

    public string Name { get; set; }

    public AdditionalInfo Info { get; set; }
}

public class AdditionalInfo
{
    public Guid Id { get; set; }

    public string Status { get; set; }
}
