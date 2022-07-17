using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionScript : MonoBehaviour
{
  
 public void BackToMainMenu(){
    gameObject.SetActive(false);
    gameObject.transform.parent.GetChild(1).gameObject.SetActive(true);
  }
}
