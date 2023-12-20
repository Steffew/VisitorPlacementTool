using UnityEngine;

public class Visitor : MonoBehaviour
{
    public bool isAdult { get; private set; }

    public Visitor(bool isAdult)
    {
        this.isAdult = isAdult;
    }

    public void Move(Seat seat)
    {
        gameObject.transform.position = seat.transform.position;
    }

    public void Move(Vector3 position)
    {
        gameObject.transform.position = position;
    }
}