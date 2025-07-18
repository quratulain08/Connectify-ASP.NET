using System;

namespace API.Entities;

public class AppUser
{
    public int Id { get; set; }   //Primary key if I write ID
    public required string UserName { get; set; }


}
