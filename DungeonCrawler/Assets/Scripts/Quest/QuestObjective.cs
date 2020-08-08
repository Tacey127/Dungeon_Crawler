using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class QuestObjective : MonoBehaviour
{
    //collection
    delegate void OnCollectItem(Item itemCollected);
    OnCollectItem onCollectItem;

    public int objectiveNumber;
    int currentCollection = 0;
    public Item itemObjective;

    bool objectiveComplete = false;

    private void Start()
    {
        onCollectItem = IncrementCollection;
    }

    void IncrementCollection(Item itemCollected)
    {
        if(itemCollected == itemObjective)
        {
            currentCollection++;
            if(currentCollection >= objectiveNumber)
            {
                //mark as completed
            }

        }
    }

}
