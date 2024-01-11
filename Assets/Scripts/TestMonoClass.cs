using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VisitorPlacementTool.Core;

public class TestMonoClass : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Test test = new Test();
        test.TestClass();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
