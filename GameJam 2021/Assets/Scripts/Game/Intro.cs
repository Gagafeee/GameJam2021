using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
   public class Intro : MonoBehaviour
   {
       public GameObject Panel;
   
       private void Start()
       {
           Panel.SetActive(true);
           StartCoroutine(HidePanel());
       }
   
       public IEnumerator HidePanel()
       {
           yield return new WaitForSeconds(16);
           BorderMagager.instance.isActive = true;
           Panel.SetActive(false);
       }
   } 
}

