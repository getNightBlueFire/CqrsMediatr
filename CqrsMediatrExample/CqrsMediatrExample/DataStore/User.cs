using System.Collections.Generic;

namespace CqrsMediatrExample.DataStore;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<int> List { get; set; }
    public Role Role { get; set; }

    public string? Email { get; set; }
}