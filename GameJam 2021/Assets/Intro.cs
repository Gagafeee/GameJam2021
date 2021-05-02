using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    public GameObject Panel;

    public void HideWall()
    {
        Panel.SetActive(false);
    }
}
