using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Stores spawn locations based on theme
/// </summary>

[CreateAssetMenu(fileName = "New Location", menuName = "Location/LocationManager")]
public class LocationManager : ScriptableObject
{
    [SerializeField] List<LocationThemeSet> SpawnThemes;
    #region GetSpawnRoom
    public GameObject getSpawnRoom(DungonTheme theme, int location)
    {
        LocationThemeSet set = getThemeSet(theme);

        GameObject returnedObject = getLocationFromTheme(set, location);


        return returnedObject;
    }

    public GameObject getRandomSpawnRoom()
    {

        DungonTheme setName = SpawnThemes[Random.Range(0, SpawnThemes.Count)].themeLocation;

        LocationThemeSet set = getThemeSet(setName);


        int location = Random.Range(0, set.locations.Count);
        GameObject returnedObject = getLocationFromTheme(set, location);


        return returnedObject;
    }

    public GameObject getRandomSpawnRoom(DungonTheme theme)
    {
        LocationThemeSet set = getThemeSet(theme);

        int location = Random.Range(0, set.locations.Count);

        GameObject returnedObject = getLocationFromTheme(set, location);


        return returnedObject;
    }

    #endregion GetSpawnRoom


    #region CollectionMethods

    /// <summary>
    /// returns null when value isn't found
    /// </summary>
    LocationThemeSet getThemeSet(DungonTheme theme)
    {
        foreach (LocationThemeSet item in SpawnThemes)
        {
            if (theme == item.themeLocation)
            {
                return item;
            }
        }

        Debug.Log("ERROR, theme not found: " + theme);
        return null;
    }

    /// <summary>
    /// returns null when value isn't found
    /// </summary>
    GameObject getLocationFromTheme(LocationThemeSet spawnSet, int location)
    {
        if(spawnSet.locations.Count < location)
        {
            Debug.Log("ERROR, location not found: " + location);
            return null;
        }
        else
        {
            return spawnSet.locations[location];
        }
    }
    #endregion CollectionMethods

}
public enum DungonTheme { ITTL, Stone }
