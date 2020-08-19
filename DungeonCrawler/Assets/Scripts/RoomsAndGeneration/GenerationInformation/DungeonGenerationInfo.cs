using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerationInfo : ScriptableObject
{
    public int seed;
    public Darkness darkness;
    public int dungeonSize;
}

public enum DungeonArchitecture { }

public enum DungeonLocation { ITTL, Stone }

public enum FurnitureType { }

public enum Darkness { Bright, Dark, Pitch }
