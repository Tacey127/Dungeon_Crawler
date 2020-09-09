using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//First and SecondPass Generation Details
public class DungeonGenerationInfo : ScriptableObject
{
    //First pass
    public int seed;
    public int dungeonSize;
    public GameObject SpawnLocation;

    //Second pass
    public FurnishingStyle furnishingStyle;
    public EncounterType encounterType;
    public LightingAmount lightingAmount;
}

