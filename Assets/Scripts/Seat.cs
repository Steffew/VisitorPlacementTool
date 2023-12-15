using UnityEngine;
using TMPro;

public class Seat : MonoBehaviour
{
    public int Id { get; private set; }
    public Visitor? Occupant { get; private set; }

    [SerializeField]
    private TextMeshProUGUI textStatus;

    private void Start()
    {
    }

    public void SetOccupant(Visitor? occupant)
    {
        Occupant = occupant;
    }

    public void SetText(string text)
    {
        textStatus.text = text;
    }
}