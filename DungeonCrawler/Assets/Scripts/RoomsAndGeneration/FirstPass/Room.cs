using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Room : MonoBehaviour {
    
    //Generation
    [SerializeField] public List<GameObject> spawnableDoors = new List<GameObject>();

    [SerializeField] RoomFurnishing furnishing;

    public bool isNormalRoom = false;
    public bool spawnedNeighbours = false;

    //debug
    public GameObject spawningfrom;

    //Collision
    public Collider roomCollider;
    public bool roomCollided = false;

    //Encounters
    [SerializeField] public bool isEncounter = false;
    public int remainingObjectives = 0;

    
    //===================================================================================Doors

    public List<GameObject> GiveDoorsToGenerator()
    {
        return spawnableDoors;
    }

    public void RemoveDoorFromList(GameObject ADoor)
    {
        spawnableDoors.Remove(ADoor);
    }

    
    public Door GetAvailableDoor()
    {
        int chosenRoom = (int)Mathf.Floor(Random.value * spawnableDoors.Count);
        return spawnableDoors[chosenRoom].GetComponent<Door>();

    }

    //==================================================================================CollisionCheck
    void OnTriggerEnter(Collider other)
    {
        roomCollided = true;
    }

    //=================================================================================Post-Spawn Generation

    public void FinaliseRoom()
    {
        if(furnishing!= null)
        {
           // furnishing.Furnish();
        }
    }

}
