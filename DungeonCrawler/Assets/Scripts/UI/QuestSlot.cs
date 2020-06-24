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
        text.text = quest.chosenRoom.ToString();



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
