using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
using static UnityEngine.EventSystems.EventTrigger;

public class StoryManager : MonoBehaviour
{
    [SerializeField] Entry currentEntry;

    [SerializeField] TextMeshProUGUI mainText;

    [SerializeField] GameObject buttonGroup;
    [SerializeField] Button[] buttonArray;

    Player player;
    Library mainLibrary;
    Library.LibraryDict library;
    //SkillChecker checker;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        mainLibrary = FindObjectOfType<Library>();
        library = mainLibrary.LibDict_ToNewRoads;
        //checker = GetComponent<SkillChecker>();
    }

    // Start is called before the first frame update
    void Start()
    {
        mainText.text = "";
        InitialiseButtonArray();
        LoadEntry(1);
    }

    private void InitialiseButtonArray()
    {
        int childCount = buttonGroup.transform.childCount;
        buttonArray = new Button[childCount];

        for (int i = 0; i < childCount; i++)
        {
            buttonArray[i] = buttonGroup.transform.GetChild(i).gameObject.GetComponent<Button>();
        }
    }

    private void LoadEntry(int idToLoad)
    {
        currentEntry = library[idToLoad];
        UpdateMainText();
        UpdateButtons();
    }

    private void UpdateMainText()
    {
        mainText.text += currentEntry.BodyText + "\n";
    }

    private void UpdateButtons()
    {
        foreach (Button button in buttonArray)
        {
            button.onClick.RemoveAllListeners();
            button.gameObject.SetActive(false);
        }

        if(currentEntry.LinkedChoices == null) { return; }

        for (int i = 0; i < currentEntry.LinkedChoices.Count; i++)
        {
            buttonArray[i].gameObject.SetActive(true);

            //Set the text for each button, including required skill if there is one
            var buttonText = buttonArray[i].gameObject.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentEntry.LinkedChoices[i].Text;
            if (currentEntry.LinkedChoices[i].SkillToCheck != null)
            {
                buttonText.text += " (Req:" + currentEntry.LinkedChoices[i].SkillToCheck + ")";
            }

            //Add OnClick event to buttons
            int currentIndex = i; //A seperate local var is needed for adding the OnClick event because of how Unity handles closures.
            buttonArray[i].onClick.AddListener(delegate { LoadEntry(currentEntry.LinkedChoices[currentIndex].LinkedEntryID); });

            //If there is a skill to check
            if (currentEntry.LinkedChoices[i].SkillToCheck != null)
            {
                //If the skill is in the players list of skills
                if(player.SkillInPlayerArray(currentEntry.LinkedChoices[i].SkillToCheck))
                {
                    buttonArray[i].interactable = true;
                }
                else
                {
                    buttonArray[i].interactable = false;
                }
            }
        }
    }
}
