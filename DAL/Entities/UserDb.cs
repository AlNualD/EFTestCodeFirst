using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFTestCodeFirst.DAL.Entities;

public class UserDb
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; }

    public string Nickname { get; set; }

    public ICollection<CharacterDb> Characters { get; set; } = new List<CharacterDb>();
}