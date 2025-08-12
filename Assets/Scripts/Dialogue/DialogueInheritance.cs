using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Dialogue))]
public class DialogueInheritance : MonoBehaviour
{
    private Dialogue dialogue;

    [SerializeField] private GameObject example1;
    [SerializeField] private GameObject example2;

    [SerializeField] private int sceneIndex = 1;

    void Awake()
    {
        dialogue = GetComponent<Dialogue>();

        dialogue.dialogueEvents[3].AddListener(ShowExample1);
        dialogue.dialogueEvents[5].AddListener(ShowExample2);

        dialogue.dialogueFinished.AddListener(DialogueFinished);
    }

    public void ShowExample1()
    {
        example1.SetActive(true);
    }

    public void HideExample1()
    {
        example1.SetActive(false);
    }

    public void ShowExample2()
    {
        example2.SetActive(true);
    }

    public void HideExample2()
    {
        example2.SetActive(false);
    }

    public void DialogueFinished()
    {
        SceneManager.LoadScene(sceneIndex);
        SavedInfo.Instance.finishedInheritance = true;
    }
}
