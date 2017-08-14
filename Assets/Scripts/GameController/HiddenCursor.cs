using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenCursor : MonoBehaviour {

    private ForExit forexit;
    private bool PausedMi;
    private bool olalimMi;

	void Start () {
        forexit = GetComponent<ForExit>();
    }

    private void Update()
    {
        PausedMi = forexit.IsPaused;
        olalimMi = forexit.OldukMu;
        PauseController();
    }

    void PauseController()
    {
        if (CanSlider.IsDead == true && olalimMi==false)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            if (PausedMi == true)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}
