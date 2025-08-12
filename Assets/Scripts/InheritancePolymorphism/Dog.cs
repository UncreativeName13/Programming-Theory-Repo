using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : Animal
{
    // INHERITANCE
    // POLYMORPHISM
    protected override void Speak()
    {
        Debug.Log("woof");
    }
}
