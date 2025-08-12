using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    // INHERITANCE

    protected virtual void Speak()
    {
        Debug.Log("speaking");
    }
}
