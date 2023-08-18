using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFTestCodeFirst.DAL.Entities;

public class CharacterDb
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; }

    public string Name { get; set; }
    
    public string? Description { get; set; }

    public int MaxHitPoints { get; set; }

    public int CurrentHitPoints { get; set; }
    
    public UserDb? User { get; set; }
}