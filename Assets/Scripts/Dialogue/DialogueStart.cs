using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Dialogue))]
public class DialogueStart : MonoBehaviour
{
    private Dialogue dialogue;
    [SerializeField] private GameObject coude;

    private Quaternion[] coudeRotations = {
        Quaternion.Euler(-70, -66, 0),
        Quaternion.Euler(-42, -29, -10),
        Quaternion.Euler(0, 0, 0)
    };

    [SerializeField] private Transform defaultCamFocus;

    [SerializeField] private Transform abstractionCamFocus;
    [SerializeField] private Transform inheritanceCamFocus;
    [SerializeField] private Transform polymorphismCamFocus;
    [SerializeField] private Transform encapsulationCamFocus;

    void Awake()
    {
        dialogue = GetComponent<Dialogue>();

        if (SavedInfo.Instance.startedInitialDialogue)
        {
            dialogue.isDialogueActive = false;
            dialogue.dialogueGameObject.SetActive(false);

            dialogue.gameObject.SetActive(false);

            return;
        }

        CoudeRotate1();

        dialogue.dialogueEvents[1].AddListener(CoudeRotate2);
        dialogue.dialogueEvents[2].AddListener(CoudeRotate3);

        dialogue.dialogueEvents[12].AddListener(FocusAbstraction);
        dialogue.dialogueEvents[13].AddListener(FocusInheritance);
        dialogue.dialogueEvents[14].AddListener(FocusPolymorphism);
        dialogue.dialogueEvents[15].AddListener(FocusEncapsulation);
        dialogue.dialogueEvents[16].AddListener(ResetCamera);

        dialogue.dialogueFinished.AddListener(DialogueFinished);
    }

    void CoudeRotate1()
    {
        coude.transform.rotation = coudeRotations[0];
    }

    void CoudeRotate2()
    {
        coude.transform.rotation = coudeRotations[1];
    }

    void CoudeRotate3()
    {
        coude.transform.rotation = coudeRotations[2];
    }

    void FocusAbstraction()
    {
        Camera.main.transform.position = abstractionCamFocus.position;
        Camera.main.transform.rotation = abstractionCamFocus.rotation;
    }

    void FocusInheritance()
    {
        Camera.main.transform.position = inheritanceCamFocus.position;
        Camera.main.transform.rotation = inheritanceCamFocus.rotation;
    }

    void FocusPolymorphism()
    {
        Camera.main.transform.position = polymorphismCamFocus.position;
        Camera.main.transform.rotation = polymorphismCamFocus.rotation;
    }

    void FocusEncapsulation()
    {
        Camera.main.transform.position = encapsulationCamFocus.position;
        Camera.main.transform.rotation = encapsulationCamFocus.rotation;
    }

    void ResetCamera()
    {
        Camera.main.transform.position = defaultCamFocus.position;
        Camera.main.transform.rotation = defaultCamFocus.rotation;
    }

    void DialogueFinished()
    {
        SavedInfo.Instance.startedInitialDialogue = true;
    }
}
