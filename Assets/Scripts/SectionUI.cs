using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SectionUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI sectionIdText;
    [SerializeField] private TextMeshProUGUI sectionDimensionsText;
    private Section section;

    public void SetSection(Section section)
    {
        this.section = section;
        sectionIdText.text = section.Id.ToString();
        sectionDimensionsText.text = $"{section.Rows}x{section.Columns}";
    }
}