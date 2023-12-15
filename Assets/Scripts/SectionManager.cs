using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionManager : MonoBehaviour
{
    private List<Section> sections = new List<Section>();

    [SerializeField]
    [Range(1, 3)]
    private int sectionCount = 5;

    [Header("Section Row Settings")]
    [SerializeField, Range(1, 5)] private int minRows;

    [SerializeField, Range(1, 5)] private int maxRows;

    [Header("Section Column Settings")]
    [SerializeField, Range(1, 5)] private int minColumns;

    [SerializeField, Range(1, 5)] private int maxColumns;

    private void Start()
    {
        GenerateSections(sectionCount);
    }

    private void Update()
    {
    }

    public void GenerateSections(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Section section = new Section(i);
            sections.Add(section);
            Debug.LogWarning($"Section {i} created.");
        }

        foreach (Section section in sections)
        {
        }
    }
}