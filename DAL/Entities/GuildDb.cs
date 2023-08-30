using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFTestCodeFirst.DAL.Entities;

public class GuildDb
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; }
    
    public string Description { get; set; }

    public int Gold { get; set; }

    [ForeignKey(nameof(CharacterDb))]
    public string? LeaderId { get; set; }

    public HashSet<CharacterDb> Characters { get; set; } = new();
}