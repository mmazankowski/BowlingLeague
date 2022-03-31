using System;
using System.ComponentModel.DataAnnotations;

namespace BowlingLeague.Models
{
    public class Bowler
    {
        [Key]
        [Required]
        public int BowlerID { get; set; } // {get;} would be a read-only variable

        public string BowlerLastName { get; set; }

        public string BowlerFirstName { get; set; }

        public string BowlerMiddleInit { get; set; }

        public string BowlerAddress { get; set; }

        public string BowlerCity { get; set; }

        public string BowlerState { get; set; }

        public string BowlerZip { get; set; }

        public string BowlerPhoneNumber { get; set; }

        //Foreign Key
        public int TeamID { get; set; }
        public Team Team { get; set; }
    }
}
