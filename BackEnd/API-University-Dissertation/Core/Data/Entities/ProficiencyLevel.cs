using System.ComponentModel.DataAnnotations;

namespace API_University_Dissertation.Core.Data.Entities;

public class ProficiencyLevel
{
    [Key]
    public int LevelId { get; set; }

    [Required]
    [StringLength(50)]
    public string LevelName { get; set; }
}