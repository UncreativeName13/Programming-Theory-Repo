using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private List<string> dialogueSubjects = new List<string>();
    [SerializeField] private List<string> dialogue = new List<string>();

    [SerializeField] private List<UnityEvent> dialogueEvents = new List<UnityEvent>();

    [SerializeField] private float pauseLength = 0.05f;

    private Dictionary<string, float> customSymbolPauseLengths = new Dictionary<string, float>();

    [SerializeField] private AudioClip dialogueSound;
    private AudioSource audioSource;

    private int currentDialogueIndex;

    [SerializeField] private GameObject dialogueGameObject;

    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI subjectText;
    [SerializeField] private GameObject proceedIndicator;

    private bool isDialogueActive;
    private bool isDialoguePlaying;

    // Start is called before the first frame update
    void Start()
    {
        if (dialogueSubjects.Count != dialogue.Count)
        {
            Debug.LogError("Mismatched amount of dialogues and dialogue subjects. Please match list size.");
        }

        currentDialogueIndex = 0;

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.spatialBlend = 0f;
        audioSource.volume = 0.5f;

        isDialogueActive = true;

        AddCustomPauses();
        AddEvents();

        StartCoroutine(StartDialogue());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isDialogueActive)
        {
            if (isDialoguePlaying)
            {
                isDialoguePlaying = false;
            }
            else
            {
                if (currentDialogueIndex >= dialogue.Count - 1)
                {
                    dialogueGameObject.SetActive(false);
                    isDialogueActive = false;
                }
                else
                {
                    currentDialogueIndex++;
                    StartCoroutine(StartDialogue());
                }
            }
        }
    }

    void AddCustomPauses()
    {
        customSymbolPauseLengths.Add(".", 0.2f);
        customSymbolPauseLengths.Add(",", 0.3f);
        customSymbolPauseLengths.Add("!", 0.3f);
        customSymbolPauseLengths.Add("?", 0.3f);
        customSymbolPauseLengths.Add(" ", 0f);
    }

    void AddEvents()
    {
        foreach (string _ in dialogue)
        {
            dialogueEvents.Add(new UnityEvent());
        }
    }

    IEnumerator StartDialogue()
    {
        string currentDialogue = dialogue[currentDialogueIndex];
        string currentSubject = dialogueSubjects[currentDialogueIndex];
        UnityEvent currentEvent = dialogueEvents[currentDialogueIndex];

        currentEvent.Invoke();

        string text = "";
        int dialogueCharIndex = 0;

        isDialoguePlaying = true;

        dialogueText.SetText(text);
        subjectText.SetText(currentSubject);

        proceedIndicator.SetActive(false);

        while (isDialoguePlaying && dialogueCharIndex < currentDialogue.Length)
        {
            string character = currentDialogue.Substring(dialogueCharIndex, 1);
            text += character;
            dialogueCharIndex++;

            dialogueText.SetText(text);

            float pause;

            if (customSymbolPauseLengths.ContainsKey(character))
            {
                pause = customSymbolPauseLengths[character];
            }
            else
            {
                pause = pauseLength;
                audioSource.PlayOneShot(dialogueSound);
            }

            yield return new WaitForSeconds(pause);
        }

        isDialoguePlaying = false;
        dialogueText.SetText(currentDialogue);

        proceedIndicator.SetActive(true);
    }
}
