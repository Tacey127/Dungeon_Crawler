using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// When a dungeon is chosen, carry info to the dungeon generator. Singleton
/// </summary>
public class DungeonInstancing : MonoBehaviour
{
    public static DungeonInstancing instance;

    [SerializeField]List<GameObject> startingRooms = new List<GameObject>();

    //the set chosen room
    public Quest chosenQuest;

    //Is the quest locked in, player is in the dungeon
    public bool questLocked = false;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    public GameObject getChosenRoom() 
    {
        return startingRooms[chosenQuest.chosenRoom];
    }


}
