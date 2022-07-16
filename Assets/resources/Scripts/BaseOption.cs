using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseOption : MonoBehaviour
{
   public GameObject buildingUI;

   public void startBuildingMode(){
    setThisActive(false);
    buildingUI.gameObject.SetActive(true);
   }

   public void setThisActive(bool boolean){
    this.gameObject.SetActive(boolean);
   }
}
