using System.Collections.Generic;

public class Section
{
    public int Id { get; private set; }

    public List<Seat> Seats { get; private set; }

    public Section(int id)
    {
        Id = id;
        Seats = new List<Seat>();
    }
}