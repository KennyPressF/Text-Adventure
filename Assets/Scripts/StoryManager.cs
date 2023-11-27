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

    public TextMeshProUGUI mainText;

    [SerializeField] GameObject buttonGroup;
    public Button[] buttonArray;

    public Player player;
    PlayerInventory inventory;
    Library mainLibrary;
    Library.LibraryDict library;
    public StoryPointManager spManager;
    public TimeKeeper timeKeeper;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        inventory = player.GetComponent<PlayerInventory>();
        mainLibrary = FindObjectOfType<Library>();
        spManager = GetComponent<StoryPointManager>();
        timeKeeper = GetComponent<TimeKeeper>();
    }

    // Start is called before the first frame update
    void Start()
    {
        InitialiseButtonArray();

        library = mainLibrary.LibDict_ToNewRoads;
        mainLibrary.PopulateLibrary(AdventureBook.ToNewRoads);

        spManager.InitializeStoryPoints();
        timeKeeper.SetNewTimeSheet();

        mainText.text = "";

        LoadEntry(1096);
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
        foreach (Button button in buttonArray)
        {
            button.onClick.RemoveAllListeners();
            button.gameObject.SetActive(false);
        }

        currentEntry = library[idToLoad];

        currentEntry.OnEntryLoad(this);
    }

    public void UpdateMainText(string text)
    {
        mainText.text += text + "\n";
    }

    public void UpdateTime(int timePassed)
    {
        timeKeeper.AdvanceTime(timePassed);

        string timeAsWord = NumberToWordConverter.ConvertToWord(timePassed);
        mainText.text += $"~ {timeAsWord} time passes.\n";
    }

    public void UpdateStamina(int staminaChange, bool staminaGained)
    {
        string staminaAsWord = NumberToWordConverter.ConvertToWord(staminaChange);

        if (staminaGained)
        {
            mainText.text += $"~ You recovered {staminaAsWord} stamina.\n";
            //TODO: Update player stamina
        }
        else
        {
            mainText.text += $"~ You lose {staminaAsWord} stamina.\n";
            //TODO: Update player stamina
        }
    }

    public void UpdateInventory(char itemID, int quantity, bool itemGained)
    {
        if (itemGained)
        {
            inventory.AddItem(itemID, quantity);
            mainText.text += $"~ You recieved an item: {inventory.itemDictionary[itemID].itemName}\n";
        }
        else
        {
            inventory.RemoveItem(itemID, quantity);
        }
    }

    public void UpdateButtons(List<PlayerChoice> availableChoices)
    {
        for (int i = 0; i < availableChoices.Count; i++)
        {
            buttonArray[i].gameObject.SetActive(true);

            //Set the text for each button, including required skill if there is one
            var buttonText = buttonArray[i].gameObject.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = availableChoices[i].Text;
            if (availableChoices[i].SkillsToCheck != null)
            {
                buttonText.text += "\n(Req: ";
                for (int s = 0; s < availableChoices[i].SkillsToCheck.Length; s++)
                {
                    if (s != 0) { buttonText.text += " or "; }
                    buttonText.text += availableChoices[i].SkillsToCheck[s];
                }
                buttonText.text += ")";

                //Check all the reuired skills and set the button to enabled if the player has at least one of them
                if (availableChoices[i].SkillsToCheck.Length > 0)
                {
                    foreach (var skill in availableChoices[i].SkillsToCheck)
                    {
                        if (player.SkillInPlayerArray(skill))
                        {
                            buttonArray[i].interactable = true;
                            break;
                        }
                        else
                        {
                            buttonArray[i].interactable = false;
                        }
                    }
                }
            }

            //Add OnClick events to buttons
            int currentIndex = i; //A seperate local var is needed for adding the OnClick event because of how Unity handles closures.

            if (availableChoices[i].SPToMark != null) //Does the choice need to mark a story point?
            {
                buttonArray[i].onClick.AddListener(delegate { spManager.MarkStoryPoint(availableChoices[currentIndex].SPToMark); });
            }

            buttonArray[i].onClick.AddListener(delegate { LoadEntry(availableChoices[currentIndex].LinkedEntryID); });
        }
    }
}
