using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{

    Dictionary<string, string> states = new Dictionary<string, string>();
    public DialogueController dialogueController;

    // Start is called before the first frame update
    void Start()
    {
        // dialogueController.CallDialogue(true, dialogueController.selectedDialogue);
        // Debug.Log(dialogueController.selectedDialogue);
    }
}
