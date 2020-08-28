using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//First and SecondPass Generation Details
public class DungeonGenerationInfo : ScriptableObject
{
    public int seed;
    public Darkness darkness;
    public int dungeonSize;
    public GameObject SpawnLocation;
}

public enum DungeonArchitecture { }



public enum FurnitureType { }

public enum Darkness { Bright, Dark, Pitch }
