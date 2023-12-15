using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SectionManager : MonoBehaviour
{
    private List<Section> sections = new List<Section>();

    [Header("Prefabs")]
    [SerializeField] private GameObject sectionPrefab;

    [SerializeField] private GameObject seatPrefab;

    [Header("General Settings")]
    [SerializeField]
    [Range(1, 5)]
    private int sectionCount;

    [Header("Section Row Settings")]
    [SerializeField, Range(1, 10)] private int minRows;

    [SerializeField, Range(1, 10)] private int maxRows;

    [Header("Section Column Settings")]
    [SerializeField, Range(1, 10)] private int minColumns;

    [SerializeField, Range(1, 10)] private int maxColumns;

    private void Awake()
    {
        GenerateSections(sectionCount);
    }

    private void Update()
    {
    }

    public void GenerateSections(int amount)
    {
        Transform transform = gameObject.transform;
        Vector3 newPosition = transform.position;

        for (int i = 0; i < amount; i++)
        {
            int rows = Random.Range(minRows, maxRows);
            int columns = Random.Range(minColumns, maxColumns);
            Section section = new Section(i + 1, rows, columns);
            sections.Add(section);
            Debug.LogWarning($"Section {i} (Rows: {rows} / Columns: {columns}) created.");
        }

        foreach (Section section in sections)
        {
            GameObject instantiatedObject = Instantiate(sectionPrefab, newPosition, Quaternion.identity, transform);
            SectionUI sectionUI = instantiatedObject.GetComponent<SectionUI>();
            sectionUI.SetSection(section);

            newPosition.x += section.Columns * 0.5f;
        }
    }
}