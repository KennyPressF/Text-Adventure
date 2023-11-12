using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class StoryManager : MonoBehaviour
{


    //Player player;
    //SkillChecker checker;

    //private void Awake()
    //{
    //    player = FindObjectOfType<Player>();
    //    checker = GetComponent<SkillChecker>();
    //}

    //// Start is called before the first frame update
    //void Start()
    //{
    //    mainText.text = "";
    //    InitialiseButtonArray();

    //    LoadCurrentEntry();
    //}

    //private void InitialiseButtonArray()
    //{
    //    int childCount = buttonGroup.transform.childCount;
    //    buttonArray = new Button[childCount];

    //    for (int i = 0; i < childCount; i++)
    //    {
    //        buttonArray[i] = buttonGroup.transform.GetChild(i).gameObject.GetComponent<Button>();
    //    }
    //}

    //private void LoadCurrentEntry()
    //{
    //    UpdateMainText();
    //    UpdateButtons();
    //}

    //private void UpdateMainText()
    //{
    //    mainText.text += "\n" + currentEntry.BodyText;
    //}

    //private void UpdateButtons()
    //{
    //    foreach (Button button in buttonArray)
    //    {
    //        button.onClick.RemoveAllListeners();
    //        button.gameObject.SetActive(false);
    //    }

    //    for (int i = 0; i < currentEntry.nextEntryArray.Length; i++)
    //    {
    //        buttonArray[i].gameObject.SetActive(true);

    //        var buttonText = buttonArray[i].gameObject.GetComponentInChildren<TextMeshProUGUI>();
    //        buttonText.text = currentEntry.responseArray[i];

    //        if (currentEntry.nextEntryArray[i].hasSkillCheck)
    //        {
    //            buttonText.text += $" ({currentEntry.nextEntryArray[i].skillCheck})";
    //        }

    //        buttonArray[i].onClick.AddListener(delegate { LoadNextEntry(); });
    //    }
    //}

    //private void LoadNextEntry()
    //{
    //    int idToLoad = EventSystem.current.currentSelectedGameObject.transform.GetSiblingIndex();
    //    nextEntry = currentEntry.nextEntryArray[idToLoad];

    //    //if(nextEntry.hasSkillCheck)
    //    //{
    //    //    bool skillCheckResult = checker.CheckForSkillSuccess(player, nextEntry);

    //    //    if(!skillCheckResult)
    //    //    {
    //    //        //nextEntry = currentEntry.nextEntryArray[idToLoad].FailedEntry;
    //    //    }
    //    //}

    //    //nextEntry.player = player;
    //    //nextEntry.ProcessEffectOnLoad();

    //    currentEntry = nextEntry;
    //    LoadCurrentEntry();
    //}

    [SerializeField] Entry currentEntry;

    [SerializeField] TextMeshProUGUI mainText;

    [SerializeField] GameObject buttonGroup;
    [SerializeField] Button[] buttonArray;

    Library storyLibrary;

    private void Start()
    {
        storyLibrary = new Library();

        currentEntry = storyLibrary.GetEntry("entry1");
        mainText.text = currentEntry.BodyText;
    }

}
