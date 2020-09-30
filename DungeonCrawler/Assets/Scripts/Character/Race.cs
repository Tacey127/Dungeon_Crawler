using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Race", menuName = "Character/NewRace")]
public class Race : ScriptableObject
{
    [Serializable]
    public struct DecorationAttribute
    {
        public string attributeName;
        public GameObject[] decorationList;
        //material for colour goes here

    }
    //custom modifiers
    public float sneakSpeed;
    public float speed;
    public float sprintSpeed;

    public float jumpHeight;

    //Size
    public float minSize;
    public float maxSize;

    public DecorationAttribute[] raceAttributes;
}
