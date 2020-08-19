using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// When a dungeon is chosen, carry info to the dungeon generator. Singleton
/// </summary>
public class DungeonInstancing : MonoBehaviour
{

    [SerializeField]List<GameObject> startingRooms = new List<GameObject>();

    //the set chosen room
    public Quest chosenQuest;

    //Is the quest locked in, player is in the dungeon
    public bool questLocked = false;

    #region Singleton
    public static DungeonInstancing instance;
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
    #endregion Singleton

    //setup of dungeon generation
    public GameObject getChosenRoom() 
    {
        // return startingRooms[chosenQuest.chosenRoom];
        return gameObject;
    }


}
