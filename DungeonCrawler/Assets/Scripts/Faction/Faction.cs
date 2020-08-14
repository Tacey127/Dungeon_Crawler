using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Faction", menuName = "Faction/BaseFaction")]
public class Faction : ScriptableObject
{
    public FactionType factionType;

    //list of radiant faction objectives he
}

public enum FactionType { Adventurers }