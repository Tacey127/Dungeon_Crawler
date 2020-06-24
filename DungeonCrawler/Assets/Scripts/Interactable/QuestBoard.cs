using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interaction to display the quest board
/// </summary>
public class QuestBoard : Interactable
{

    public override void Interact(PlayerInteraction interact)
    {
        //connect to the quest board
        //get player quest UI enabled.
        interact.inputInterface.EnableQuestScreen();
    }


}
