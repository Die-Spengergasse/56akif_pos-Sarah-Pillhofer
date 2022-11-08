using System;

public class Concert
{
	public Concert()
	{
        public int Id { get; set; }
        public Band Band { get; set; } = default!;
        public DateTime ConcertDateAndTime { get; set; }
        public string Location { get; set; } = string.Empty;
        public ConcertCategory ConcertCategory { get; set; } = default!;
    }
}
