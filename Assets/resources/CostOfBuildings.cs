using System.Collections.Generic;
using UnityEngine;

public class CostOfBuildings : MonoBehaviour
{
    public List<ItemCostClass> itemCostsList = new List<ItemCostClass>
    { 
                new ItemCostClass("Blacksmith",80,80),
                new ItemCostClass("Cult",300,500),
                new ItemCostClass("Dock",100,100),
                new ItemCostClass("Farm",20,60),
                new ItemCostClass("House",30,80),
                new ItemCostClass("Lumber",10,10)
                
    };

    void Start()
    {
    }
}

public class ItemCostClass
{

    public int lumberCost;
    public int moneyCost;
    public string name;

    public ItemCostClass(string name, int lumberCost, int moneyCost)
    {
        this.name = name;
        this.lumberCost = lumberCost;
        this.moneyCost = moneyCost;
    }

}