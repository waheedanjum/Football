using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Football.Data.Model
{
    public partial class Teams
    {
        public Teams()
        {
            MatchesGuestNavigation = new HashSet<Matches>();
            MatchesHomeNavigation = new HashSet<Matches>();
        }

        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        [StringLength(50)]
        public string Code { get; set; }

        [InverseProperty("GuestNavigation")]
        public virtual ICollection<Matches> MatchesGuestNavigation { get; set; }
        [InverseProperty("HomeNavigation")]
        public virtual ICollection<Matches> MatchesHomeNavigation { get; set; }
    }
}