using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickToGoToScene : MonoBehaviour
{
    [SerializeField] private int sceneIndex;
    private Material material;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
    }

    void OnMouseEnter()
    {
        if (SavedInfo.Instance.startedInitialDialogue)
            material.EnableKeyword("_EMISSION");
    }

    void OnMouseExit()
    {
        if (SavedInfo.Instance.startedInitialDialogue)
            material.DisableKeyword("_EMISSION");
    }

    void OnMouseDown()
    {
        if (SavedInfo.Instance.startedInitialDialogue)
            SceneManager.LoadScene(sceneIndex);
    }
}
