using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropdownManager : MonoBehaviour
{
    [SerializeField] private LayoutManager layoutManager;
    [SerializeField] private VisitorManager visitorManager;
    private int groupSize = 3;
    private float childChanceMin = 0.2f;
    private float childChanceMax = 0.4f;

    public void SetLayoutValues(int index)
    {
        switch (index)
        {
            case 0: // Tiny
                layoutManager.SetLayoutParameters(1, 2, 2, 1, 3);
                break;

            case 1: // Small
                layoutManager.SetLayoutParameters(2, 2, 4, 2, 4);
                break;

            case 2: // Medium
                layoutManager.SetLayoutParameters(3, 3, 5, 3, 6);
                break;

            case 3: // Large
                layoutManager.SetLayoutParameters(3, 5, 8, 6, 8);
                break;

            case 4: // Extreme
                layoutManager.SetLayoutParameters(4, 4, 9, 5, 9);
                break;
        }
    }

    public void SetRandomizeRotation(int index)
    {
        switch (index)
        {
            case 0: // Enabled
                layoutManager.SetRandomizeRotation(true);
                break;

            case 1: // Disabled
                layoutManager.SetRandomizeRotation(false);
                break;
        }
    }

    public void SetGroupSize(int index)
    {
        switch (index)
        {
            case 0: // 1 person;
                groupSize = 1;
                break;
            case 1: // 2 people;
                groupSize = 2;
                break;
            case 2: // 3 people;
                groupSize = 3;
                break;
            case 3: // 4 people;
                groupSize = 4;
                break;
            case 4: // 5 people;
                groupSize = 5;
                break;
            case 5: // 6 people;
                groupSize = 6;
                break;
        }
    }

    public void SetAdultChance(int index)
    {
        switch (index)
        {
            case 0: // 0 - 20;
                childChanceMin = 0;
                childChanceMax = 0.2f;
                break;
            case 1: // 20 - 40;
                childChanceMin = 0.2f;
                childChanceMax = 0.4f;
                break;
            case 2: // 40 - 60;
                childChanceMin = 0.4f;
                childChanceMax = 0.6f;
                break;
            case 3: // 60 - 80;
                childChanceMin = 0.6f;
                childChanceMax = 0.8f;
                break;
            case 4: // 80 - 100;
                childChanceMin = 0.8f;
                childChanceMax = 1;
                break;
        }
    }
}