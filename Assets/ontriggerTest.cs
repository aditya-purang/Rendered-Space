using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ontriggerTest : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered");
    }
}
