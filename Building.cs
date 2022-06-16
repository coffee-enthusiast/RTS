using System.Collections;
using UnityEngine;

public class Building : MonoBehaviour
{
    public string bName;
    public string bDescription;

    public Resource resourceProduced;
    public Resource resourceNeeded;
    public Resource resourceToUpgrade;
    public int costPerProduct;

    float amountPerSecond;
    public float timeToProduce;
    public float amountProduced;
    public int amountToProduce;
    public int amount;

    public int upgradeCost;
    public int level;
    public int maxLevel;
    public int addMaxResources;

    private void Start()
    {
        timeToProduce = resourceProduced.unitTime;
        if (resourceProduced.resourceType == ResourceType.Produced)
            amountPerSecond = 1f / timeToProduce;

        level = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (amountToProduce > 0)
        {
            amountProduced += amountPerSecond * Time.deltaTime;
            if (amountProduced >= 1)
            {
                Debug.Log("1 " + resourceProduced.resourceTag + " unit produced!");
                GameManager.Instance.AddResource(resourceProduced.resourceTag);
                amountProduced = 0;
                amountToProduce--;
            }
        }
    }

    public void ProduceResources()
    {
        if (GameManager.Instance.PayResource(resourceNeeded.resourceTag, costPerProduct * amount))
            amountToProduce += amount;
        else
            Debug.Log("Not enough resources!!");
    }

    public void Upgrade()
    {

        if (GameManager.Instance.PayResource(resourceToUpgrade.resourceTag, upgradeCost * level) && level < maxLevel)
        {
            if (timeToProduce > 1)
                timeToProduce -= 1;

            if (costPerProduct > 1)
                costPerProduct -= 1;

            amountPerSecond = 1f / timeToProduce;
            level++;
            amount++;

            if (resourceProduced.resourceTag != ResourceTag.Unit)
                GameManager.Instance.maxResources += addMaxResources;

            Debug.Log("Upgrade done!");

        }
        else
            Debug.Log("Not enough resources or Max Level reached!!");
    }
}
