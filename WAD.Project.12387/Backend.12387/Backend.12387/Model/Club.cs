using System;
using System.Collections.Generic;

namespace Backend._12387.Model
{
    public class Club
    {
        public int ClubId { get; set; }
        public string Name { get; set; }
        public string CoachName { get; set; }
        public string StadiumName { get; set; }
        public string ImageLink { get; set; }
        public DateTime FoundedYear { get; set; }
        public League League { get; set; }
        public ICollection<Player> Players { get; set; }
    }
}
