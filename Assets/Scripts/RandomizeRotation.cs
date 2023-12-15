using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeRotation : MonoBehaviour
{
    [SerializeField] private float minRotation;
    [SerializeField] private float maxRotation;

    private void Awake()
    {
        transform.rotation = Quaternion.Euler(0, Random.Range(minRotation, maxRotation), 0);
    }
}