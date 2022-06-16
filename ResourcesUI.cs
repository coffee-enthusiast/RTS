using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesUI : MonoBehaviour
{
    public Text gold;
    public Text rock;
    public Text wood;
    public Text bread;
    public Text units;

    public void UpdateUI(int g, int w, int r, int b, int u, int maxR, int maxU)
    {
        wood.text = "Wood: " + w + "/" + maxR + " |";
        rock.text = "Rock: " + r + "/" + maxR + " |";
        gold.text = "Gold: " + g + "/" + maxR +" |";
        bread.text = "Bread: " + b + "/" + maxR + " |";
        units.text = "Units: " + u + "/" + maxU + " |";
    }
}
