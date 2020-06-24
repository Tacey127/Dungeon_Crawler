using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HUDManager : UIManager
{
    public Text interactionText;

    public void SetInteractionText(string iText) 
    {
        interactionText.text = iText;
    }

}
