using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Football.Data.Model
{
    public partial class Matches
    {
        public int ID { get; set; }
        public int Home { get; set; }
        public int Guest { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime MatchDate { get; set; }
        public int HomeScore { get; set; }
        public int GuestScore { get; set; }

        [ForeignKey("Guest")]
        [InverseProperty("MatchesGuestNavigation")]
        public virtual Teams GuestNavigation { get; set; }
        [ForeignKey("Home")]
        [InverseProperty("MatchesHomeNavigation")]
        public virtual Teams HomeNavigation { get; set; }
    }
}