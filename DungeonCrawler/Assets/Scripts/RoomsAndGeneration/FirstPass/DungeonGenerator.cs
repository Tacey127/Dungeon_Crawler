﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
	//seed and dungeonsize in dungeon instancing
	int seed = 0;
	int dungeonSize = 3;
	//
	[SerializeField] List<GameObject> roomList = new List<GameObject>();
	//
	List<GameObject> doorList = new List<GameObject>();
	GameObject chosenStartRoom;

    #region Init
    void Start()
	{
		//turn off physics
		Physics.autoSimulation = false;

		//Init
		SetupGenerationParameters();
		//First pass
		StartGeneration();

		//Second Pass
		foreach (GameObject room in roomList)
		{
			room.GetComponent<Room>().FinaliseRoom();
		}

		//turn on physics
		Physics.autoSimulation = true;
	}

	void SetupGenerationParameters()
    {
		DungeonGenerationInfo generationInfo = DungeonInstancing.instance.chosenQuest.generationInfo;

		if (generationInfo.SpawnLocation == null)
		{
			Debug.Log("SpawnLocation Not set");
		}
		chosenStartRoom = generationInfo.SpawnLocation;



		dungeonSize = generationInfo.dungeonSize;
		seed = generationInfo.seed;
		Random.InitState(seed);
    }

	void StartGeneration()
	{
		if (DungeonInstancing.instance != null)
		{
			SpawnStartRoom();

			for (int i = 0; i < dungeonSize; i++)
			{
				GenerationLoop();
			}

		}
	}

    #endregion Init

    #region List
    GameObject ChooseListObject(GameObject[] rl)
	{
		int chosenRoom = (int)Mathf.Floor(Random.value * rl.Length);

		return rl[chosenRoom];
	}
	void shrinkList(int indexToRemove, List<GameObject> listToShrink)
	{
		listToShrink.RemoveAt(indexToRemove);

		List<GameObject> newlist = new List<GameObject>();
		foreach (GameObject item in listToShrink)
		{
			if (item != null)
			{
				newlist.Add(item);
			}
		}

		listToShrink.Clear();
		listToShrink.AddRange(newlist);
	}
    #endregion list

    #region Generation
    void SpawnStartRoom()
	{
		//Room Spawns
		GameObject roomObject = Instantiate(chosenStartRoom, transform);

		//Add room to list
		Room r = roomObject.GetComponent<Room>();
		roomList.Add(roomObject);

		r.roomCollider.isTrigger = true;

		doorList.AddRange(r.GiveDoorsToGenerator());
	}

	void GenerationLoop()
	{
		//choose a door, spawn a hallway from it

		GameObject chosenDoor = ChooseListObject(doorList.ToArray());
		Door cDoor = chosenDoor.GetComponent<Door>();

		GameObject hallwayObject = SpawnFromDoor(chosenDoor, cDoor.ChooseRoom());
		GameObject disableObject = cDoor.parentRoom;

		if (!AttemptCollisionCheck(hallwayObject, disableObject))//Has the collision failed
		{
			Destroy(hallwayObject);
		}
		else
		{

			//if the collsisioncheck comes back clean, continue
			Door nextDoor = hallwayObject.GetComponent<Room>().GetAvailableDoor();
			GameObject roomObject = SpawnFromDoor(nextDoor.gameObject, nextDoor.ChooseRoom());

			disableObject = nextDoor.parentRoom;
			//collisioncheck
			if (!AttemptCollisionCheck(roomObject, disableObject))
			{
				Destroy(hallwayObject);
				Destroy(roomObject);
			}
			else
			{
				//add the rooms to the list
				roomList.Add(hallwayObject);
				roomList.Add(roomObject);

				//adjust spawnable door list
				shrinkList(doorList.IndexOf(chosenDoor), doorList);
				doorList.AddRange(hallwayObject.GetComponent<Room>().GiveDoorsToGenerator());
				shrinkList(doorList.IndexOf(nextDoor.gameObject), doorList);
				doorList.AddRange(roomObject.GetComponent<Room>().GiveDoorsToGenerator());

				//hide doors
				cDoor.FinaliseDoorType();
				nextDoor.FinaliseDoorType();
			}
		}

		FirstPassCleanUp();
	}

	public GameObject SpawnFromDoor(GameObject aDoor, GameObject newRoom)
	{
		//Gets the world position and rotation of the the rooms chosen door
		Door spawningDoor = aDoor.GetComponent<Door>();
		Quaternion startRotation = aDoor.transform.rotation;

		//move place this relative position according to the parentRooms worldSpace
		Vector3 roomPos = spawningDoor.truePosition.transform.position;

		//Choose a room from the spawnable list and create
		newRoom = Instantiate(newRoom, roomPos, Quaternion.identity, transform);
		Room spawnedRoom = newRoom.GetComponent<Room>();

		//spawnedRoom.spawningfrom = aDoor; //DEBUG

		//Pick a entry from the hallway to connect to
		GameObject bChosenDoor = ChooseListObject(spawnedRoom.spawnableDoors.ToArray());
		Door spawnedDoor = bChosenDoor.GetComponent<Door>();
		Room SpawnedRoom = spawnedDoor.parentRoom.GetComponent<Room>();

		//hide the connectingDoor(for now)
		SpawnedRoom.RemoveDoorFromList(bChosenDoor);
		spawnedDoor.FinaliseDoorType();

		//rotate the newRoom to face the room 
		Quaternion altRotation = bChosenDoor.transform.rotation;
		newRoom.transform.Rotate(0, (startRotation.eulerAngles.y + 180) - altRotation.eulerAngles.y, 0);

		//Move the newRoom to its new location
		newRoom.transform.Translate(-spawnedDoor.truePosition.transform.localPosition);

		return newRoom;
	}

	void FirstPassCleanUp()
	{
		foreach (GameObject room in roomList)
		{
			room.GetComponent<Collider>().enabled = false;
		}
	}

    #endregion Generation

	#region Collision
    /// <summary>
    /// Is there a collision while ignoring the latter object  
    /// </summary>
    /// <param name="check">The collider to be checked</param>
    /// <param name="disable">The Collider to be disabled</param>
    /// <returns></returns>
    public bool AttemptCollisionCheck(GameObject check, GameObject disable)
	{
		//simulate physics to let instantiate spawn the room(numbers go wrong otherwise), check the ontriggerenter/get list of colliding objects
		Collider disabledCollider = disable.GetComponent<Room>().roomCollider;
		Room checkCollider = check.GetComponent<Room>();

		//turn off disable room collider
		disable.SetActive(false);

		//iterate the physics
		Physics.Simulate(0.0002f);

		//turn on the disable room collider
		disable.SetActive(true);

		return !checkCollider.roomCollided;
	}
    #endregion Collision
}
