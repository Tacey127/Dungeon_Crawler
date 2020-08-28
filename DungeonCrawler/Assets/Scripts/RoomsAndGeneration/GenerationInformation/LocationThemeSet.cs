using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Location", menuName = "Location/ThemeSet")]
public class LocationThemeSet : ScriptableObject
{
    public DungonTheme themeLocation;
    public List<GameObject> locations;
}
