using System.ComponentModel.DataAnnotations;

namespace Mission10_Whetten.Data;

// Class for the team data
public class Team
{
    [Key][Required]
    public int TeamID { get; set; }
    [Required]
    public string TeamName { get; set; }
    public int? CaptainID { get; set; }
}