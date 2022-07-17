using System.Collections.Generic;
using UnityEngine;

public class CostOfBuildings : MonoBehaviour
{
    public List<ItemCostClass> itemCostsList = new List<ItemCostClass>
    {
                new ItemCostClass("Blacksmith",70,50),
                new ItemCostClass("Dice Temple",50,70),
                new ItemCostClass("Dock",300,500),
                new ItemCostClass("Farm",20,20),
                new ItemCostClass("House",10,10),
                new ItemCostClass("Lumber Camp",30,30)

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