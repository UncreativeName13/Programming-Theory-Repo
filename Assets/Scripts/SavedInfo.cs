using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedInfo : MonoBehaviour
{
    // ENCAPSULATION
    public static SavedInfo Instance
    {
        get;
        private set;
    }

    public bool startedInitialDialogue = false;

    public bool finishedAbstraction = false;
    public bool finishedInheritance = false;
    public bool finishedPolymorphism = false;
    public bool finishedEncapsulation = false;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
