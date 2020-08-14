using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

/// <summary>
/// Display quest if any
/// </summary>
public class QuestSlot : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] Button selectionButton;

    Quest quest;
    public void AddQuest(Quest newQuest)
    {
        quest = newQuest;

        SetupQuestText();
        text.enabled = true;
        selectionButton.interactable = true;
    }

    void SetupQuestText()
    {
      //  text.text = ConvertLocationIntToString(quest.chosenRoom);
    }

    string ConvertLocationIntToString(int chosenRoom)
    {
        string location = "";
      /*  switch (quest.chosenRoom)
        {

            case 0:
                location = "ITTL";
                break;
            case 1:
                location = "Stone fort";
                break;
            default:
                location = "Quest Location Not Found";
                break;
        }
      */
        return location;
    }


    public void ClearSlot()
    {
        text.text = "";
        text.enabled = false;
        selectionButton.interactable = false;
    }

    public void OnSelectionButton()
    {
        Debug.Log("QuestSelected");
        DungeonInstancing.instance.chosenQuest = quest;
    }

}
