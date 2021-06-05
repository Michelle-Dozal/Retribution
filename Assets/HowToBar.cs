using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToBar : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject HowToBarPanel;
    bool isOpen;
    
   public void OpenHowToBar(){  
       HowToBarPanel.SetActive(true);
       
       isOpen = !isOpen;
       HowToBarPanel.SetActive(isOpen);
       /*if(HowToBarPanel != null){
           bool isOpen = HowToBarPanel.activeSelf;

           HowToBarPanel.SetActive(!isOpen);
        }*/
    }

}
