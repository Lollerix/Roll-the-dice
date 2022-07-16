using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UtilsScript : MonoBehaviour
{
 
 void Start(){
    costOfBuildings = costOfBuildingsObject.GetComponent<CostOfBuildings>();
 }
 
    public GameObject costOfBuildingsObject;
    CostOfBuildings costOfBuildings;
     public ItemCostClass findCost(string name)
    {
        List<ItemCostClass> lista = costOfBuildings.itemCostsList;
        foreach(ItemCostClass item in lista){
            if(item.name.Equals(name)){
                return item;
            }
        }
        return new ItemCostClass("ERROR", 999, 999);
    }

}
