using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Animal
{
    // INHERITANCE
    // POLYMORPHISM
    protected override void Speak()
    {
        Debug.Log("meow");
    }
}
