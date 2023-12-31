using System.Collections.Generic;

public class Section
{
    public int Id { get; private set; }
    public List<Seat> Seats { get; private set; }
    public List<Seat> AvailableSeats { get; private set; }
    public int Rows { get; private set; }
    public int Columns { get; private set; }

    public Section(int id, int rows, int columns)
    {
        Id = id;
        Seats = new List<Seat>();
        AvailableSeats = new List<Seat>();
        Rows = rows;
        Columns = columns;
    }

    public void OccupySeat(Seat seat, Visitor visitor)
    {
        seat.SetOccupant(visitor);
        AvailableSeats.Remove(seat);
    }

    public void SetAvailableSeats(List<Seat> seats)
    {
        AvailableSeats = seats;
    }
}