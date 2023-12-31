using System.Data.Common;
using UnityEngine;

public class Seat : MonoBehaviour
{
    public int Id { get; private set; }
    public Visitor Occupant { get; private set; }

    public void SetId(int id)
    {
        Id = id;
    }

    public void SetOccupant(Visitor occupant)
    {
        Occupant = occupant;
    }
}