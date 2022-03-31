using System;
using System.ComponentModel.DataAnnotations;

namespace BowlingLeague.Models
{
    public class Bowler
    {
        [Key]
        [Required]
        public int BowlerID { get; set; } // {get;} would be a read-only variable

        [Required(ErrorMessage = "Please enter a first name!")]
        public string BowlerFirstName { get; set; }

        public string BowlerMiddleInit { get; set; }

        [Required(ErrorMessage = "Please enter a last name!")]
        public string BowlerLastName { get; set; }

        [Required(ErrorMessage = "Please enter a address!")]
        public string BowlerAddress { get; set; }

        [Required(ErrorMessage = "Please enter a city!")]
        public string BowlerCity { get; set; }

        [Required(ErrorMessage = "Please enter a state!")]
        public string BowlerState { get; set; }

        [Required(ErrorMessage = "Please enter a zip!")]
        public string BowlerZip { get; set; }

        [Required(ErrorMessage = "Please enter a phone number!")]
        public string BowlerPhoneNumber { get; set; }

        //Foreign Key
        [Required(ErrorMessage = "Please select a team!")]
        public int TeamID { get; set; }
        public Team Team { get; set; }
    }
}
