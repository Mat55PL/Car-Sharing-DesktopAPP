using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Car_SharingDesktopAPP.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Login użytkownika jest wymagany!")]
        [StringLength(50, ErrorMessage = "Login nie może być dłuższy niż 50 znaków")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Imię użytkownika jest wymagane!")]
        [StringLength(50, ErrorMessage = "Imię nie może być dłuższe niż 50 znaków")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        [StringLength(75, ErrorMessage = "Nazwisko nie może być dłuższe niż 75 znaków")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Adres Email jest wymagany!")]
        [EmailAddress(ErrorMessage = "Podaj poprawny adres email!")]
        public string Email { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 6)]
        //[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,100}$", 
            //ErrorMessage = "Hasło musi zawierać co najmniej jedną wielką literę, jedną małą literę, " +
            //"jedną cyfrę oraz jeden znak specjalny.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Numer telefonu jest wymagany.")]
        [Phone(ErrorMessage = "Wprowadź poprawny numer telefonu.")]
        public string PhoneNumber { get; set; }
        public bool IsDocumentsVerified { get; set; }
        public UserRank Rank { get; set; }
        
        public User(int id, string login, string firstName, string lastName, string email, string password, string phoneNumber, bool isDocumentVerified,  UserRank rank)
        {
            Id = id;
            Login = login;
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
