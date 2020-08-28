using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class QuestGenerator : MonoBehaviour
{
   [SerializeField] int questMaximum = 5;

    public List<Quest> generatedQuests = new List<Quest>();

    //To be pontentially converted to singleton later
    [SerializeField] FactionManager factionManager;
    [SerializeField] LocationManager locationManager;

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

        newQuest.faction = factionManager.GetFaction();

        newQuest.generationInfo = SetupGenerationInfo();

        return newQuest;
    }

    /// <summary>
    /// Sets up the attributes of the dungeon, such as:
    /// seed, dungeonsize, spawnroom
    /// </summary>
    DungeonGenerationInfo SetupGenerationInfo()
    {
        //ScriptableObject.CreateInstance<MyScriptableObject>();
        DungeonGenerationInfo generationInfo = ScriptableObject.CreateInstance <DungeonGenerationInfo>();

        generationInfo.seed = (int)(Random.value * float.MaxValue);
        generationInfo.dungeonSize = 20;
        generationInfo.SpawnLocation = locationManager.getRandomSpawnRoom();

        return generationInfo;
    }
    /*
    QuestObjective GetObjective()
    {

    }
    */
}


