using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Mission10_Whetten.Data;

// Class for the bowler data
public class Bowler
{
    [Key][Required]
    public int BowlerID { get; set; }
    [ForeignKey("TeamID")]
    public Team? Team {get; set;}
    public string? BowlerLastName { get; set; }
    public string? BowlerFirstName { get; set; }
    public string? BowlerMiddleInit { get; set; }
    public string? BowlerAddress { get; set; }
    public string? BowlerCity { get; set; }
    public string? BowlerState { get; set; }
    public string? BowlerZip { get; set; }
    public string? BowlerPhoneNumber { get; set; }
    public int? TeamID { get; set; }
}