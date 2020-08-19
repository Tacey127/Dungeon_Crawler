using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class QuestGenerator : MonoBehaviour
{
   [SerializeField] int questMaximum = 5;

    public List<Quest> generatedQuests = new List<Quest>();

    [SerializeField] FactionManager factionManager;

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
        Quest newQuest = new Quest();

        newQuest.factionType = GetFactionType();

        return newQuest;
    }

    FactionType GetFactionType()
    {
        return factionManager.GetFaction().factionType;
    }
    /*
    QuestObjective GetObjective()
    {

    }
    */
}


