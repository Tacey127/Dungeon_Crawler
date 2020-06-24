using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// General purpose UI manager for each screen
/// </summary>
public class UIManager : MonoBehaviour
{
    [SerializeField] InputInterface userInterface;
    [SerializeField] GameObject screen;
    public void SwitchScreen(bool setActive)
    {
        screen.SetActive(setActive);
    }

    public void ExitToUI()
    {
        userInterface.ExitToHUD();
    }
}
