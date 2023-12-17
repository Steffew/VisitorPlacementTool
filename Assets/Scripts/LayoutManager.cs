using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class LayoutManager : MonoBehaviour
{
    private List<Section> sections = new List<Section>();

    [Header("Prefabs")]
    [SerializeField] private GameObject sectionPrefab;

    [SerializeField] private GameObject seatPrefab;

    [Header("General Settings")]
    [SerializeField]
    [Range(1, 5)]
    private int sectionCount;

    [Header("Section Column Settings")]
    [SerializeField, Range(1, 10)] private int minColumns;

    [SerializeField, Range(1, 10)] private int maxColumns;

    [Header("Section Row Settings")]
    [SerializeField, Range(1, 10)] private int minRows;

    [SerializeField, Range(1, 10)] private int maxRows;

    [Header("Miscellaneous")]
    [SerializeField] private bool randomizeRotation;

    public void GenerateSections()
    {
        Transform transform = gameObject.transform;
        Vector3 newSectionPosition = transform.position;

        for (int i = 0; i < sectionCount; i++)
        {
            int rows = Random.Range(minRows, maxRows);
            int columns = Random.Range(minColumns, maxColumns);
            Section section = new Section(i + 1, rows, columns);
            sections.Add(section);
        }

        foreach (Section section in sections)
        {
            GameObject newSection = Instantiate(sectionPrefab, newSectionPosition, Quaternion.identity, transform);
            SectionUI sectionUI = newSection.GetComponent<SectionUI>();
            sectionUI.SetSection(section);

            for (int c = 0; c < section.Columns; c++)
            {
                newSectionPosition.x += 0.5f;

                for (int r = 0; r < section.Rows; r++)
                {
                    GameObject rowSeat = Instantiate(seatPrefab, new Vector3(newSectionPosition.x, newSectionPosition.y, newSectionPosition.z - (r * 0.5f)), Quaternion.identity, newSection.transform);

                    section.Seats.Add(rowSeat.GetComponent<Seat>());

                    if (randomizeRotation)
                    {
                        float randomYRotation = Random.Range(-10f, 10f);
                        rowSeat.transform.Rotate(0, randomYRotation, 0);
                    }
                }
            }

            Debug.Log($"Section {section.Id} has {section.Seats.Count} seats.");

            newSectionPosition.x += 1;
        }
    }

    public void ClearLayout()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        sections.Clear();
    }

    public void SetLayoutParameters(int sectionCount, int minColumns, int maxColumns, int minRows, int maxRows)
    {
        this.sectionCount = sectionCount;
        this.minColumns = minColumns;
        this.maxColumns = maxColumns;
        this.minRows = minRows;
        this.maxRows = maxRows;
    }

    public void SetRandomizeRotation(bool randomizeRotation)
    {
        this.randomizeRotation = randomizeRotation;
    }
}