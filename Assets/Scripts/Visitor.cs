using UnityEngine;

public class Visitor : MonoBehaviour
{
    public int Id { get; private set; }
    public bool IsAdult { get; private set; }

    public void Initialize(int id, bool isAdult)
    {
        Id = id;
        IsAdult = isAdult;
    }

    public void MoveTo(Seat seat)
    {
        gameObject.transform.position = seat.transform.position;
    }

    public void MoveTo(Vector3 position)
    {
        gameObject.transform.position = position;
    }
}