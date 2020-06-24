using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class LoadDungeon : Interactable
{
    //Convert me to int
    [SerializeField] string SceneName = "";
    [SerializeField] bool ignoreQuestPreset = false;

    public Quest questOption;

    public override void Interact(PlayerInteraction interact)
    {
        if(!ignoreQuestPreset)
            DungeonInstancing.instance.chosenQuest = questOption;
        LoadLevel();
    }

    void LoadLevel()
    {
        SceneManager.LoadScene(SceneName);
    }


}
