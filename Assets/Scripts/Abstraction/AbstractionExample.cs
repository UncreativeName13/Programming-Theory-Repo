using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractionExample : MonoBehaviour
{
    // ABSTRACTION
    public static int TripleResult1(int num)
    {
        return num + num + num;
    }

    public static int TripleResult2(int num)
    {
        return num * 3;
    }
}
