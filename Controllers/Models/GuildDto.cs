namespace EFTestCodeFirst.Controllers.Models;

public class GuildDto
{
    public string Id { get; set; }
    
    public string Description { get; set; }

    public int Gold { get; set; }
}

public class NewGuildDto
{
    public string Description { get; set; }

    public int Gold { get; set; }
}