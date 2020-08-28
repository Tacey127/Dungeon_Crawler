using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Faction", menuName = "Faction/FactionManager")]
public class FactionManager : ScriptableObject
{
    [SerializeField] List<Faction> factions;

    public Faction GetFaction()
    {
        if(factions.Count == 0)
        {
            Debug.Log("No factions in factionManager");
        }

        return factions[0];
    }


}
