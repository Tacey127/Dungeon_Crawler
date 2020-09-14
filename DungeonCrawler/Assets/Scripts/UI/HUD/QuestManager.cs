using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

/// <summary>
/// Shows either the generated quests for the player to select or the current quest while within the dungeon.
/// </summary>
public class QuestManager : UIScreen
{

    QuestManager()
    {
        uiShown = UIShown.Quest;
        cursorMode = CursorLockMode.Confined;
        stopTimeOnScreen = true;
    }

    public Transform questsParent;
    //generates quests
    [SerializeField] QuestGenerator generator;

    QuestSlot[] slots;

    int page = 0;

    void Start()
    {
        if(!DungeonInstancing.instance.questLocked)
        {
            generator.GenerateQuests();
        }

        slots = questsParent.GetComponentsInChildren<QuestSlot>();

        UpdateQuestScreen();
    }

    public void UpdateQuestScreen()
    {
        if (DungeonInstancing.instance.questLocked)
        {
            //display the chosen quest
        }
        else
        {
            // 0 - 3
            for (int i = 0; i < slots.Length; i++)
            {
                int questLoc = i + (page * slots.Length);

                if (questLoc < generator.generatedQuests.Count)
                {
                    //display 3 quests
                    slots[i].AddQuest(generator.generatedQuests[questLoc]);
                }
                else
                {
                    slots[i].ClearSlot();
                }
            }
        }

    }
}
