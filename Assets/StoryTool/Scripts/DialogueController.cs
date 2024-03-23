using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueController : MonoBehaviour
{
    // DECLARATIONS

    //Entries
    //[create a new entry for each dialogue series] & when desired, call with it's specified variable name.
    Dictionary<string, List<DialogueEntry>> storyList = new Dictionary<string, List<DialogueEntry>>();

    public List<DialogueEntry> dialogueEntries;
    public List<DialogueEntry> dialogueTutorial;
    public List<DialogueEntry> dialogueStory;

    public List<List<DialogueEntry>> dialoguesList;
    

    //UI Prefabs
    public GameObject horizontalPrefab;
    public GameObject fullscreenPrefab;

    public TextMeshProUGUI mainTextHorizontal;
    public TextMeshProUGUI mainTextFullscreen;

    public Button buttonOneHorizontal;
    public Button buttonOneFullscreen;

    // Selected Dialogue
    public List<DialogueEntry> selectedDialogue = new List<DialogueEntry>();

    // Story Index
    public int dialogueIndex = 0;

    // Dialogue boolean between Fullscreen and Horizontal
    public bool isFullscreen;

    public enum Characters
    {

    }

    void Start()
    {
        // Manually add each Dialogue Entry List into Dictionary
        storyList.Add("test", dialogueEntries);
        storyList.Add("tutorial", dialogueTutorial);

        // Listeners for buttons
        buttonOneHorizontal.onClick.AddListener(executeDialogue);
        buttonOneFullscreen.onClick.AddListener(executeDialogue);

        // Select story from declared dialogue entries.
        SelectDialogue(dialogueStory);
        Debug.Log("selected dialogue: " + selectedDialogue);

        //  Update content at the script call
        UpdateDialogue(dialogueIndex);

        CallDialogue(true, selectedDialogue);
    }

    public void executeDialogue()   //executeDialogue
    {
                                                                                                        //increase story index
                                                                                               //update story according to current index
                //console logging for tracking issues

        if (dialogueIndex +1 < selectedDialogue.Count)
        {
            dialogueIndex += 1;
            UpdateDialogue(dialogueIndex);
            Debug.Log("current story index: " + this.dialogueIndex + " story is as follows: " + this.mainTextHorizontal);
        }
        else
        {
            fullscreenPrefab.SetActive(false);
            horizontalPrefab.SetActive(false);
            Debug.Log("Dialogue has been disabled due to index is bigger than list length");
        }

        
    }

    public void UpdateDialogue(int _dialogueIndex)     //updates selected story according to given index
    {
        Debug.Log("Function: UpdateDialogue has been called");

       
        //update main text
        mainTextHorizontal.text = selectedDialogue[_dialogueIndex].text;
        mainTextFullscreen.text = selectedDialogue[_dialogueIndex].text;

        //update button one texts
        buttonOneHorizontal.GetComponentInChildren<TextMeshProUGUI>().text = selectedDialogue[_dialogueIndex].optionOneText;
        buttonOneFullscreen.GetComponentInChildren<TextMeshProUGUI>().text = selectedDialogue[_dialogueIndex].optionOneText;
        Debug.Log("Function: UpdateDialogue has been executed");
    }

    public void SelectDialogue(List<DialogueEntry> _selectedDialogue)
    {
        Debug.Log("Function: SelectDialogue has been called");

        //update selected dialogue with given parameter above
        selectedDialogue = _selectedDialogue;
      
        Debug.Log("Function: SelectDialogue has been executed");
    }

    public void CallDialogue(bool isFullscreen, List<DialogueEntry> dialogue)
    {
        Debug.Log("Function: CallDialogue is called");

        SelectDialogue(dialogue);
        UpdateDialogue(0);

        if (isFullscreen == true) {
            fullscreenPrefab.SetActive(true);
            Debug.Log("Fullscreen Dialogue has been enabled");
        }
        else {
            horizontalPrefab.SetActive(true);
            Debug.Log("Horizontal Dialogue has been enabled");
        }

        Debug.Log("Function: CallDialogue has been executed");
    }

}

public class Character
{
    Sprite characterImage;
    string name;
}
