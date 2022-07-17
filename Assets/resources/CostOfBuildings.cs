using System.Collections.Generic;
using UnityEngine;

public class CostOfBuildings : MonoBehaviour
{
    public List<ItemCostClass> itemCostsList = new List<ItemCostClass>
    {
                new ItemCostClass("Blacksmith",70,50,"This is a blacksmith." + System.Environment.NewLine + "For each die that is forging new item here, ALL roll of dice get +1 to the result"),
                new ItemCostClass("Dice Temple",50,70, "This is a dice temple." + System.Environment.NewLine + "For each die that is praying here, the maximum result ALL die can get is increased by two"),
                new ItemCostClass("Dock",300,500, "This is a dock." + System.Environment.NewLine + "Coming soon..."),
                new ItemCostClass("Farm",20,20, "This is a farm." + System.Environment.NewLine + "Each worker that is farming here produce their dice roll in food"),
                new ItemCostClass("House",10,10, "This is a house. Dice automatically come to live here." + System.Environment.NewLine + "The house increase your worker capacity, but each die consume 2 food. " + System.Environment.NewLine +  "Every resident pay 1 coin to you each production cycle."),
                new ItemCostClass("Lumber Camp",30,30, "This is a lumber camp." + System.Environment.NewLine + "Each worker that is chopping wood here produce their dice roll in wood")

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
    public string description;

    public ItemCostClass(string name, int lumberCost, int moneyCost, string description)
    {
        this.name = name;
        this.lumberCost = lumberCost;
        this.moneyCost = moneyCost;
        this.description = description;
    }

}