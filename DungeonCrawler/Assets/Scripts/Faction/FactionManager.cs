using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Faction", menuName = "Faction/FactionManager")]
public class FactionManager : ScriptableObject
{
    [SerializeField] List<Faction> factions;

    public Faction GetFaction()
    {
        return factions[0];
    }


}
