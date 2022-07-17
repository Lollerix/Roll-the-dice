using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialButton : MonoBehaviour
{

    private bool alreadyBeenThere = false;
    public void DisableBuildingTutorial()
    {
        if (!alreadyBeenThere)
        {
            gameObject.SetActive(false);
            GameObject placeBuildingTutorial = transform.parent.transform.Find("PlaceBuildingTutorial").gameObject;
            placeBuildingTutorial.gameObject.SetActive(true);
            alreadyBeenThere = true;
        }
    }

    public void DisablePlaceBuildingTutorial()
    {
        gameObject.SetActive(false);
        GameObject placeBuildingTutorial = transform.parent.transform.Find("RightClickTutorial").gameObject;
        placeBuildingTutorial.gameObject.SetActive(true);
    }

    public void DisableRightClickTutorial()
    {
        gameObject.SetActive(false);
        GameObject placeBuildingTutorial = transform.parent.transform.Find("OptionPanelTutorial").gameObject;
        placeBuildingTutorial.gameObject.SetActive(true);
    }

    public void DisableOptionPanelTutorial()
    {
        gameObject.SetActive(false);
        GameObject placeBuildingTutorial = transform.parent.transform.Find("OptionPanelTutorial2").gameObject;
        placeBuildingTutorial.gameObject.SetActive(true);
    }

    public void DisableOptionPanelTutorial2()
    {
        gameObject.SetActive(false);
        GameObject placeBuildingTutorial = transform.parent.transform.Find("OptionPanelTutorial3").gameObject;
        placeBuildingTutorial.gameObject.SetActive(true);
    }

     public void DisableOptionPanelTutorial3()
    {
        gameObject.SetActive(false);
    }
}
