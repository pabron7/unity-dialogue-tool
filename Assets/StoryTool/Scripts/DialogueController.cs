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

    List<List<DialogueEntry>> dialoguesList;

    public List<CharacterEntry> characterList;

    //UI Prefabs
    public GameObject horizontalPrefab;
    public GameObject fullscreenPrefab;

    public TextMeshProUGUI mainTextHorizontal;
    public TextMeshProUGUI mainTextFullscreen;

    public Button buttonOneHorizontal;
    public Button buttonOneFullscreen;

    public Image horizontalCharacterHolder;
    public Sprite fullscreenCharacterHolder;

    public TextMeshProUGUI horizontalCharacterName;
    public TextMeshProUGUI fullscreenCharacterName;

    // Selected Dialogue & character
    List<DialogueEntry> selectedDialogue = new List<DialogueEntry>();
    Characters selectedCharacter;

    // Story Index
    int dialogueIndex = 0;

    // Dialogue boolean between Fullscreen and Horizontal
    bool isFullscreen;

    //  CHARACTER DECLARATIONS
    public enum Characters
    {
        ogre,
        lizard
    }

    Characters characters;

    void Start()
    {
        // Manually add each Dialogue Entry List into Dictionary
        storyList.Add("test", dialogueEntries);
        storyList.Add("tutorial", dialogueTutorial);

        // Listeners for buttons
        buttonOneHorizontal.onClick.AddListener(executeDialogue);
        buttonOneFullscreen.onClick.AddListener(executeDialogue);

        // Select story from declared dialogue entries.
        SelectDialogue(dialogueEntries);
        Debug.Log("selected dialogue: " + selectedDialogue);

        //  Update content at the script call
        UpdateDialogue(dialogueIndex);

        CallDialogue(false, selectedDialogue);
    }

    public void executeDialogue()   //executeDialogue
    {
                

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

        //update images & name  ====> MANUALLY ADD & EDIT IF BLOCKS FOR EACH CHARACTER

        if (selectedDialogue[_dialogueIndex].character == Characters.ogre)
        {
            horizontalCharacterHolder.GetComponent<Image>().sprite = characterList[0].image;
            horizontalCharacterName.GetComponent<TextMeshProUGUI>().text = characterList[0].name;
        }
        else if (selectedDialogue[_dialogueIndex].character == Characters.lizard)
        {
            horizontalCharacterHolder.GetComponentInChildren<Image>().sprite = characterList[1].image;
            horizontalCharacterName.GetComponent<TextMeshProUGUI>().text = characterList[1].name;
        };


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
