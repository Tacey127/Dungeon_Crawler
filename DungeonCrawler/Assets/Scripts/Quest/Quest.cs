using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Quest
{
    public FactionType factionType;//adventurers, scavengers, etc
    public List<QuestObjective> objectives;
    public DungeonLocation location;

    public Darkness darkness;
}
public enum Objective { Collect }
public enum DungeonLocation { ITTL, Stone }
public enum Darkness { Bright, Dark, Pitch}
