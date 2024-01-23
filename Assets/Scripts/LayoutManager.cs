using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using VisitorPlacementTool.Core;
using UnityEngine;

public class LayoutManager : MonoBehaviour
{
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

    private VisitorPlacementTool.Core.Layout layout = new Layout();

    public void GenerateSections()
    {
        Transform transform = gameObject.transform;
        Vector3 newSectionPosition = transform.position;

        for (int i = 0; i < sectionCount; i++)
        {
            int rows = Random.Range(minRows, maxRows);
            int columns = Random.Range(minColumns, maxColumns);
            Section section = new Section(i + 1, rows, columns);

            layout.AddSection(rows, columns);
        }

        foreach (VisitorPlacementTool.Core.Section section in layout.Sections)
        {
            GameObject newSection = Instantiate(sectionPrefab, newSectionPosition, Quaternion.identity, transform);
            SectionUI sectionUI = newSection.GetComponent<SectionUI>();
            sectionUI.SetText(section.Id.ToString(), section.Rows.ToString(), section.Columns.ToString());

            for (int c = 0; c < section.Columns; c++)
            {
                newSectionPosition.x += 0.5f;

                for (int r = 0; r < section.Rows; r++)
                {
                    GameObject rowSeat = Instantiate(seatPrefab, new Vector3(newSectionPosition.x, newSectionPosition.y, newSectionPosition.z - (r * 0.5f)), Quaternion.identity, newSection.transform);

                    section.Seats.Add(new VisitorPlacementTool.Core.Seat(section.Seats.Count, r, c)); //todo: duplicate seats in section

                    rowSeat.GetComponent<Seat>().SetId(section.Seats.Count);

                    if (randomizeRotation)
                    {
                        float randomYRotation = Random.Range(-10f, 10f);
                        rowSeat.transform.Rotate(0, randomYRotation, 0);
                    }

                    Debug.Log($"Seat {section.Seats.Count} - {r+1}/{c+1}.");
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

        layout.ClearSections();
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

    //public List<Section> GetSections()
    //{
    //    return VisitorPlacementTool.Core.Layout;
    //}
}