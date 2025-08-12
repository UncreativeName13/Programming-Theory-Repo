using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedInfo : MonoBehaviour
{
    // ENCAPSULATION (i think)
    public static SavedInfo Instance
    {
        get;
        private set;
    }

    public bool startedInitialDialogue = false;

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
