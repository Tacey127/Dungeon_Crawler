using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Quest
{
    public int chosenRoom;
    public Darkness darkness;
    public int faction;//adventurers, scavengers, etc

}

public enum Darkness { Bright, Dark, Pitch}
