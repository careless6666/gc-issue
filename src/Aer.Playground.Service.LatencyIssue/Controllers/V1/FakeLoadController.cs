using System;
using System.Threading;
using System.Threading.Tasks;
using Aer.Playground.Service.LatencyIssue.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Aer.Playground.Service.LatencyIssue.Controllers.V1;

[Route("fake-work")]
public class FakeLoadController: Controller
{
    private readonly IFakeWorkService _fakeWorkService;

    public FakeLoadController(IFakeWorkService fakeWorkService)
    {
        _fakeWorkService = fakeWorkService;
    }

    [HttpPost("init")]
    public void Init()
    {
        _fakeWorkService.InitData();
    }

    [HttpGet("user")]
    public async Task<Response> GetData(CancellationToken token)
    {
        var id = Random.Shared.Next(100_000);
        var user = await _fakeWorkService.GetUser(id, token);

        if (user == null)
            throw new Exception("not found " + id);

        return new Response
        {
            Id = user.Id,
            Name = user.Name,
            Info = new Response.AdditionalInfo
            {
                Id = user.Info.Id,
                Status = user.Info.Status
            }
        };
    }

    [HttpGet("/ready")]
    public string Ready(CancellationToken token)
    {
        return "Healthy";
    }


    [HttpGet("/live")]
    public string Live(CancellationToken token)
    {
        return "Healthy";
    }
}

public class Response
{
    public long Id { get; set; }

    public string Name { get; set; }

    public AdditionalInfo Info { get; set; }

    public class AdditionalInfo
    {
        public Guid Id { get; set; }

        public string Status { get; set; }
    }
}
