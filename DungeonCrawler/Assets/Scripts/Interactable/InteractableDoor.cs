using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class InteractableDoor : Interactable
{
    [SerializeField] bool isLevelLoader = false;
    [SerializeField] string SceneName = "";

    public override void Interact(PlayerInteraction interact)
    {
        if (isLevelLoader)
        {
            LoadLevel();
        }
        else 
        {
            OpenDoor();
        }
    }

    void LoadLevel()
    {
        SceneManager.LoadScene(SceneName);
    }
    void OpenDoor()
    {
        gameObject.SetActive(false);
    }


}
