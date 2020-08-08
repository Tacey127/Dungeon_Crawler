using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the heads up display
/// </summary>
public class HUDManager : UIManager
{
    public Text interactionText;

    public void SetInteractionText(string iText) 
    {
        interactionText.text = iText;
    }

}
