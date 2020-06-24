using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGenerator : MonoBehaviour
{
   [SerializeField] int questMaximum = 5;
   [SerializeField] int questMinimum = 1;

    [SerializeField] int dungeonStartingRooms = 2;

    [SerializeField] public List<Quest> generatedQuests = new List<Quest>();

    // Start is called before the first frame update
    public void GenerateQuests()
    {
        for (int i = 0; i < questMaximum; i++)
        {
            generatedQuests.Add(SetupQuest());
        }
    }

    Quest SetupQuest()
    {
        Quest newQuest;
        newQuest.chosenRoom = Random.Range(0, dungeonStartingRooms);
        newQuest.faction = 0;
        newQuest.darkness = Darkness.Bright;

        return newQuest;
    }
}


