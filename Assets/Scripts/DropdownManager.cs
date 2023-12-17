using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropdownManager : MonoBehaviour
{
    [SerializeField]
    private LayoutManager layoutManager;

    public void SetLayoutValues(int index)
    {
        Debug.Log($"Selected layout: {index}");
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
        Debug.Log($"Selected layout: {index}");
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
}