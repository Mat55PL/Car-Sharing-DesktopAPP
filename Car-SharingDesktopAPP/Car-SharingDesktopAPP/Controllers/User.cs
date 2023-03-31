using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_SharingDesktopAPP.Controllers
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsDocumentsVerified { get; set; }
        public UserRank Rank { get; set; }


        public User(int id, string firstName, string lastName, string email, string password, string phoneNumber, bool isDocumentVerified,  UserRank rank)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
            IsDocumentsVerified = isDocumentVerified;
            Rank = rank;
        }

        public User() { }
    }
}

public enum UserRank
{
    User = 0,
    Support = 1,
    Technician = 2,
    Owner = 99
}
