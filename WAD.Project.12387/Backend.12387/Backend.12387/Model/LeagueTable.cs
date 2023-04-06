namespace Backend._12387.Model
{
    public class LeagueTable
    {
        public int LeagueTableId { get; set; }
        public int Position { get; set; }
        public int PlayedGames { get; set; }
        public int Won { get; set; }
        public int Draw { get; set; }
        public int Lost { get; set; }   
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }
        public int Points { get; set; }
        public League League { get; set; }
        public Club Club { get; set; }
    }
}
