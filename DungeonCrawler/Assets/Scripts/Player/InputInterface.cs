using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputInterface : MonoBehaviour
{
    public enum UIShown
    {
        HUD,
        Pause,
        Quest,
        Inventory
    }

    UIShown currentUI = UIShown.HUD;

    [SerializeField] PauseManager pauseManager;
    [SerializeField] public QuestManager questManager;
    [SerializeField] public HUDManager hudManager;
    [SerializeField] InventoryManager inventoryManager;

    // Update is called once per frame
    void Update()
    {

        //adjust for deeper pause sceens
        if (Input.GetButtonDown("Pause"))
        {
            switch (currentUI)
            {
                case UIShown.HUD://we pause the game
                    SwitchUIShown(UIShown.Pause);
                    break;

                //resume the game
                case UIShown.Pause:
                case UIShown.Quest:
                case UIShown.Inventory:
                    SwitchUIShown(UIShown.HUD);
                    break;
                default:
                    break;
            }

        }

        if (Input.GetButtonDown("Inventory") && currentUI == UIShown.HUD)
        {
            SwitchUIShown(UIShown.Inventory);
            inventoryManager.UpdateInventoryUI();
        }

    }

    void SwitchUIShown(UIShown ui)
    {
        currentUI = ui;

        switch (ui)
        {
            case UIShown.HUD:
                HandleTime(false);
                Cursor.lockState = CursorLockMode.Locked;

                hudManager.SwitchScreen(true);
                pauseManager.SwitchScreen(false);
                questManager.SwitchScreen(false);
                inventoryManager.SwitchScreen(false);
                break;
            case UIShown.Pause:
                HandleTime(true);
                Cursor.lockState = CursorLockMode.None;

                hudManager.SwitchScreen(false);
                pauseManager.SwitchScreen(true);
                questManager.SwitchScreen(false);
                inventoryManager.SwitchScreen(false);
                break;
            case UIShown.Quest:
                HandleTime(true);
                Cursor.lockState = CursorLockMode.None;

                hudManager.SwitchScreen(false);
                pauseManager.SwitchScreen(false);
                questManager.SwitchScreen(true);
                inventoryManager.SwitchScreen(false);
                break;
            case UIShown.Inventory:
                HandleTime(true);
                Cursor.lockState = CursorLockMode.None;

                hudManager.SwitchScreen(false);
                pauseManager.SwitchScreen(false);
                questManager.SwitchScreen(false);
                inventoryManager.SwitchScreen(true);
                break;
            default:
                break;
        }
    }

    //
    public void ExitToHUD()
    {
        SwitchUIShown(UIShown.HUD);
    }

    void HandleTime(bool timeStop)
    {
        if (timeStop)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
 
    //============Quest Manager
    /// <summary>
    /// Enables the quest screen, disables the hud
    /// </summary>
    public void EnableQuestScreen()
    {
        SwitchUIShown(UIShown.Quest);
    }

}
