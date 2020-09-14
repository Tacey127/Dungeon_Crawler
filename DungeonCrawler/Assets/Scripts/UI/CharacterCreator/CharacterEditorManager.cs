using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEditorManager : UIScreen
{
    CharacterEditorManager()
    {
        uiShown = UIShown.CharacterEditor;
        cursorMode = CursorLockMode.Confined;
        stopTimeOnScreen = true;
    }
}
