using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//provides details to playerStats
public class PlayerHandler : MonoBehaviour
{
    #region Singleton
    public static PlayerHandler instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
    }
    #endregion Singleton

    [SerializeField] Race playerRace;

    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] CharacterStats characterStats;

    [SerializeField] bool buttonUsed = false;

    private void Update()
    {
        if(buttonUsed)
        {
            playerMovement.speed = playerRace.speed;
            playerMovement.jumpHeight = playerRace.jumpHeight;
            buttonUsed = false;
        }
    }



}
