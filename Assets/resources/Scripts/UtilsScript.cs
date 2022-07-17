using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UtilsScript : MonoBehaviour
{
    static CostOfBuildings costOfBuildings;
    private void Awake()
    {
        costOfBuildings = GameObject.Find("CostOfBuildings").GetComponent<CostOfBuildings>();
    }
    public static ItemCostClass findCost(string name)
    {
        List<ItemCostClass> lista = costOfBuildings.itemCostsList;
        foreach (ItemCostClass item in lista)
        {
            if (item.name.Equals(name))
            {
                return item;
            }
        }
        return new ItemCostClass("ERROR", 999, 999, "ERROR");
    }

}
