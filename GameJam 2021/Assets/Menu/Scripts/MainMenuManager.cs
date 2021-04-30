using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public Animator mainPanelAnimator;

    public void enlargePanel()
    {
        mainPanelAnimator.SetBool("isTargeted", true);
    }

    public void minimizePanel()
    {
        mainPanelAnimator.SetBool("isTargeted", false);
    }
}
