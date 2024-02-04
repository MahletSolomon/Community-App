using System;

namespace MainProject.MVVM.Model;

public class UserInformationModel
{
    public string Id { get; set; }
    public string Username { get; set; }
    public string ProfilePictureUrl { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; }
    public int TotalLike { get; set; }
    public int TotalPost { get; set; }
}