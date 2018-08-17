using System;
namespace WebAPI.Models
{
    // TODO Move user model to ProjectCore/Models and delete Models folder in WebAPI project
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public User(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
