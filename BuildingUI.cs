using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingUI : MonoBehaviour
{

    public GameObject panel;
    public Text buildingName;
    public Text buildingDescription;
    public Text produceCost;
    public Text upgradeCost;
    public Building myBuilding;
    

    private void Start()
    {

    }
    public void Hide()
    {
        panel.SetActive(false);
    }

    public void UnHide()
    {

        buildingName.text = myBuilding.bName + " (Level " + myBuilding.level+")";
        buildingDescription.text = myBuilding.bDescription 
            + "\n" + "Cost: " + myBuilding.costPerProduct + " " + myBuilding.resourceNeeded.resourceName
            + "\n" + "Upgrade Cost: " + (myBuilding.upgradeCost * myBuilding.level) + " " + myBuilding.resourceToUpgrade.resourceName;
        produceCost.text = "Produce: " + myBuilding.amount 
            + "\n Cost: "+(myBuilding.amount * myBuilding.costPerProduct) + " " + myBuilding.resourceNeeded.resourceName;
        panel.SetActive(true);
    }

}
