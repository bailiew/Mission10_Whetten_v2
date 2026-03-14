using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission10_Whetten.Data;

namespace Mission10_Whetten.Controllers;

[Route("/[controller]")]
[ApiController]
public class BowlerController : ControllerBase
{
    private BowlerDbContext _bowlerContext;

    public BowlerController(BowlerDbContext temp)
    {
        _bowlerContext = temp;
    }

    [HttpGet(Name = "GetBowler")]
    public IEnumerable<object> Get()
    {
        var bowlerList = _bowlerContext.Bowlers
            .Include(b => b.Team)
            .Where(b => b.Team != null && (b.Team.TeamName == "Marlins" || b.Team.TeamName == "Sharks"))
            .Select(b => new
            {
                BowlerID = b.BowlerID,
                BowlerFirstName = b.BowlerFirstName,
                BowlerMiddleInit = b.BowlerMiddleInit,
                BowlerLastName = b.BowlerLastName,
                TeamName = b.Team.TeamName,
                BowlerAddress = b.BowlerAddress,
                BowlerCity = b.BowlerCity,
                BowlerState = b.BowlerState,
                BowlerZip = b.BowlerZip,
                BowlerPhoneNumber = b.BowlerPhoneNumber
            })
            .ToList();
        return bowlerList;
    }
}