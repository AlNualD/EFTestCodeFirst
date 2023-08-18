namespace EFTestCodeFirst.Controllers.Models;

public class CharacterDto
{
    public string Id { get; set; }

    public string Name { get; set; }

    public int MaxHitPoints { get; set; }

    public int CurrentHitPoints { get; set; }
}

public class NewCharacterDto
{
    public string Name { get; set; }

    public int MaxHitPoints { get; set; }

    public int CurrentHitPoints { get; set; }
}