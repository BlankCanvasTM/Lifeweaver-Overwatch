using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float destroyDelay = 1.0f; // The time delay before destroying the GameObject

    void Start()
    {
        // Call the DestroyObject() function after destroyDelay seconds
        Invoke("DestroyObject", destroyDelay);
    }

    void DestroyObject()
    {
        // Destroy the GameObject this script is attached to
        Destroy(gameObject);
    }
}
