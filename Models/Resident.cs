using System.ComponentModel.DataAnnotations;

namespace Vaskebjørnen.Models
{
    public class Resident
    {
        private string _appartmentNumber;
        private string _name;
        private string _password;

        public Resident() 
        { 
        
        }

        public Resident(string appartmentNumber, string name, string password)
        {
            _appartmentNumber = appartmentNumber;
            _name = name;
            _password = password;
        }

        [Required]
        [StringLength(3, ErrorMessage = "Appartment Number length must be 3 characters.")]
        [RegularExpression(@"^[0-4]\.[A-E]$", ErrorMessage = "Appartment Number must be in the format '0.A' where 0-4 is the floor and A-E is the apartment.")]
        public string AppartmentNumber
        { 
            get { return _appartmentNumber; }
            set { _appartmentNumber = value; }
        }

        [Required]
        [StringLength(40, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 1)]
        public string Name 
        {
            get { return _name; } 
            set { _name = value; }
        }

        [Required]
        public string Password
        { 
            get { return _password; } 
            set { _password = value; }
        }

        

        


    }
}
