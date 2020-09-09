using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Quest
{
    public Faction faction;//adventurers, scavengers, etc
    public List<QuestObjective> objectives;

    public DungeonGenerationInfo generationInfo;
    public DungonTheme dungonTheme;

}