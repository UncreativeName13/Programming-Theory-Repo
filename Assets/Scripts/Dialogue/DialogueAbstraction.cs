using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Dialogue))]
public class DialogueAbstraction : MonoBehaviour
{
    private Dialogue dialogue;

    [SerializeField] private GameObject example1;
    [SerializeField] private GameObject example2;
    [SerializeField] private GameObject example3;
    [SerializeField] private GameObject example4;

    [SerializeField] private int sceneIndex = 1;

    void Awake()
    {
        dialogue = GetComponent<Dialogue>();

        dialogue.dialogueEvents[3].AddListener(ShowExample1);
        dialogue.dialogueEvents[5].AddListener(HideExample1);

        dialogue.dialogueEvents[6].AddListener(ShowExample2);
        dialogue.dialogueEvents[8].AddListener(HideExample2);

        dialogue.dialogueEvents[9].AddListener(ShowExample3);

        dialogue.dialogueEvents[11].AddListener(HideExample3);
        dialogue.dialogueEvents[11].AddListener(ShowExample4);

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

    public void ShowExample3()
    {
        example3.SetActive(true);
    }

    public void HideExample3()
    {
        example3.SetActive(false);
    }

    public void ShowExample4()
    {
        example4.SetActive(true);
    }

    public void DialogueFinished()
    {
        SceneManager.LoadScene(sceneIndex);
        SavedInfo.Instance.finishedAbstraction = true;
    }
}
