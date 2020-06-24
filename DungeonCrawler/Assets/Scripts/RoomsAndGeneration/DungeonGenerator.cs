using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DungeonGenerator : MonoBehaviour {

	//Variables that can change
	//How big is the dungon from Root to stem

	[SerializeField] int seed = 0;
	[SerializeField] int dungeonSize = 3;
	//Different rooms
	[SerializeField] GameObject[] startRooms;
	[SerializeField] GameObject[] rooms;
	[SerializeField] GameObject[] hallways;

	[SerializeField] GameObject[] endRooms;

	//Doors
	[SerializeField] List<GameObject> doorList = new List<GameObject>();
	//
	void Start()
	{
		//turn off physics
		Physics.autoSimulation = false;

		Random.InitState(seed);
		seed = (int)(Random.value * 10000);
		StartGeneration();

		//turn on physics
		Physics.autoSimulation = true;
	}

	void StartGeneration()
	{
		if (startRooms.Length != 0)
		{
			SpawnStartRoom();

			for (int i = 0; i < dungeonSize; i++)
			{
				GenerationLoop();
			}

		}
	}

	void GenerationLoop()
	{
		//choose a door, spawn a hallway from it

		GameObject chosenDoor = ChooseListObject(doorList.ToArray());

		GameObject hallwayObject = SpawnFromDoor(chosenDoor, hallways);
		GameObject doorParent = chosenDoor.GetComponent<Door>().parentRoom;

		if (!AttemptCollisionCheck(hallwayObject, doorParent))//Has the collision failed
		{
			Destroy(hallwayObject);
		}
		else
		{

			//if the collsisioncheck comes back clean, continue
			//select door from hallway
			Door nextDoor = hallwayObject.GetComponent<Room>().GetAvailableDoor();
			//spawn a room from that hallway
			GameObject roomObject = SpawnFromDoor(nextDoor.gameObject, rooms);
			doorParent = nextDoor.parentRoom;
			//collisioncheck
			if (!AttemptCollisionCheck(roomObject, doorParent))
			{
				Destroy(hallwayObject);
				Destroy(roomObject);
			}
			else
			{
				//adjust spawnable door list
				shrinkList(doorList.IndexOf(chosenDoor), doorList);
				doorList.AddRange(hallwayObject.GetComponent<Room>().GiveDoorsToGenerator());
				shrinkList(doorList.IndexOf(nextDoor.gameObject), doorList);
				doorList.AddRange(roomObject.GetComponent<Room>().GiveDoorsToGenerator());

				//Process doors
				chosenDoor.SetActive(false);

				Debug.Log("a", nextDoor.gameObject);
				nextDoor.gameObject.SetActive(false);

			}
		}

	
	}

	void GenerationCleanUp()
	{
		
	}

	//==================================================================List

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

	//=====================================================================Generation
	void SpawnStartRoom()
	{
		//Room Spawns
		GameObject roomObject = Instantiate(ChooseListObject(startRooms), transform);

		//Add room to list
		Room r = roomObject.GetComponent<Room>();



		r.roomCollider.isTrigger = true;

		doorList.AddRange(r.GiveDoorsToGenerator());
	}
	public GameObject SpawnFromDoor(GameObject aDoor, GameObject[] roomList)
	{
		//Gets the world position and rotation of the the rooms chosen door
		Door spawningDoor = aDoor.GetComponent<Door>();
		Quaternion startRotation = aDoor.transform.rotation;

		//move place this relative position according to the parentRooms worldSpace
		Vector3 roomPos = spawningDoor.truePosition.transform.position;

		//Choose a room from the spawnable list and create
		GameObject newRoom = ChooseListObject(roomList);
		newRoom = Instantiate(newRoom, roomPos, Quaternion.identity, transform);
		Room spawnedRoom = newRoom.GetComponent<Room>();

		spawnedRoom.spawningfrom = aDoor;

		//Pick a entry from the hallway to connect to
		GameObject bChosenDoor = ChooseListObject(spawnedRoom.spawnableDoors.ToArray());
		Door spawnedDoor = bChosenDoor.GetComponent<Door>();
		Room SpawnedRoom = spawnedDoor.parentRoom.GetComponent<Room>();

		//hide the connectingDoor(for now)
		SpawnedRoom.RemoveDoorFromList(bChosenDoor);
		bChosenDoor.SetActive(false);


		//rotate the newRoom to face the room 
		Quaternion altRotation = bChosenDoor.transform.rotation;
		newRoom.transform.Rotate(0, (startRotation.eulerAngles.y + 180) - altRotation.eulerAngles.y, 0);

		//Move the newRoom to its new location
		newRoom.transform.Translate(-spawnedDoor.truePosition.transform.localPosition);

		return newRoom;
	}

	//==================================================================================Collision

	/// <summary>
	/// Returns true if there is a collision, while ignoring another  
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
		Physics.Simulate(0.0002f);//find efficient number?

		//turn on the disable room collider
		disable.SetActive(true);

		return !checkCollider.roomCollided;
	}

}
