using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SectionUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI sectionIdText;
    [SerializeField] private TextMeshProUGUI sectionDimensionsText;
    private Section section;

    public void SetText(string id, string rows, string columns)
    {
        sectionIdText.text = id;
        sectionDimensionsText.text = $"{columns}x{rows}";
    }
}