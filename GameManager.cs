using System.Collections;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public int WoodAmount;
    public int GoldAmount;
    public int RockAmount;
    public int BreadAmount;
    public int UnitsAmount;
    public int maxUnitsAmount;

    public int maxUnits;
    public int maxResources;

    public GameObject unitPrefab;
    public ResourcesUI resUI;

    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.Log("Game Manager Instance is null!!");
                
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
        maxUnits = 6;
        maxResources = 20;
        resUI.UpdateUI(GoldAmount, WoodAmount, RockAmount, BreadAmount, UnitsAmount, maxResources, maxUnits);
    }

    public void AddResource(ResourceTag rT)
    {
        if (rT == ResourceTag.Bread && BreadAmount < maxResources)
            BreadAmount++;
        else if (rT == ResourceTag.Gold && GoldAmount < maxResources)
            GoldAmount++;
        else if (rT == ResourceTag.Wood && WoodAmount < maxResources)
            WoodAmount++;
        else if (rT == ResourceTag.Unit && UnitsAmount < maxUnits)
            UnitsAmount++;
        else if (rT == ResourceTag.Rock && RockAmount < maxResources)
            RockAmount++;
        

        resUI.UpdateUI(GoldAmount, WoodAmount, RockAmount,BreadAmount, UnitsAmount,  maxResources, maxUnits);
    }

    public bool PayResource(ResourceTag rT, int amount)
    {
        if (rT == ResourceTag.Bread && BreadAmount >= amount)
        {
            BreadAmount -= amount;
            resUI.UpdateUI(GoldAmount, WoodAmount, RockAmount, BreadAmount, UnitsAmount, maxResources, maxUnits);
            return true;
        }
        else if (rT == ResourceTag.Gold && GoldAmount >= amount)
        {
            GoldAmount -= amount;
            resUI.UpdateUI(GoldAmount, WoodAmount, RockAmount, BreadAmount, UnitsAmount, maxResources, maxUnits);
            return true;
        }
        else if (rT == ResourceTag.Wood && WoodAmount >= amount)
        {
            WoodAmount -= amount;
            resUI.UpdateUI(GoldAmount, WoodAmount, RockAmount, BreadAmount, UnitsAmount, maxResources, maxUnits);
            return true;
        }
        else if (rT == ResourceTag.Unit && UnitsAmount >= amount)
        {
            UnitsAmount -= amount;
            resUI.UpdateUI(GoldAmount, WoodAmount, RockAmount, BreadAmount, UnitsAmount, maxResources, maxUnits);
            return true;
        }
        else if (rT == ResourceTag.Rock && RockAmount >= amount)
        {
            RockAmount -= amount;
            resUI.UpdateUI(GoldAmount, WoodAmount, RockAmount, BreadAmount, UnitsAmount, maxResources, maxUnits);
            return true;
        }

        return false;
    }
}
