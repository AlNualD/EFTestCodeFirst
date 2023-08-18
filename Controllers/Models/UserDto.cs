namespace EFTestCodeFirst.Controllers.Models;

public class UserDto
{
    public string UserId { get; set; }
    public string Nickname { get; set; }
}

public class NewUserDto
{
    public string Nickname { get; set; }
}