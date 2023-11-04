using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    private static CursorManager instance;

    //makes instance of singleton
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        HideCursor();
    }

    /// <summary>
    /// hides the cursor and locks it in screen
    /// </summary>
    public void HideCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    /// <summary>
    /// shows the cursor and unlocks it
    /// </summary>
    public void ShowCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    /// <summary>
    /// Cursor Manager Instance: used to show and hide the cursor
    /// </summary>
    public static CursorManager Instance
    {
        get { return instance; }
    }
}
