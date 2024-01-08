using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropdownManager : MonoBehaviour
{
    [SerializeField] private LayoutManager layoutManager;
    [SerializeField] private VisitorManager visitorManager;

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
        visitorManager.SetParameters(index + 1); 
    }

    public void SetAdultChance(int index)
    {
        switch (index)
        {
            case 0: // 0 - 20;
                visitorManager.SetParameters(0, 0.2f); 
                break;
            case 1: // 20 - 40;
                visitorManager.SetParameters(0.2f, 0.4f); 
                break;
            case 2: // 40 - 60;
                visitorManager.SetParameters(0.4f, 0.6f); 
                break;
            case 3: // 60 - 80;
                visitorManager.SetParameters(0.6f, 0.8f); 
                break;
            case 4: // 80 - 100;
                visitorManager.SetParameters(0.8f, 1); 
                break;
        }
    }
}