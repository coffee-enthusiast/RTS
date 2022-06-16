using System.Collections;
using UnityEngine;

public class House : MonoBehaviour
{
    public string bName;
    public string bDescription;

    public Unit woodGatherer;
    public Unit goldGatherer;
    public Unit rockGatherer;
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

    int counter;
    private void Start()
    {
        timeToProduce = 5;
        
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
                if (counter % 3 == 0)
                    Instantiate(woodGatherer);
                else if (counter % 3 == 1)
                    Instantiate(rockGatherer);
                else
                    Instantiate(goldGatherer);

                GameManager.Instance.AddResource(ResourceTag.Unit);
                amountProduced = 0;
                amountToProduce--;
                counter++;
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

            GameManager.Instance.maxUnits += addMaxResources;


            Debug.Log("Upgrade done!");

        }
        else
            Debug.Log("Not enough resources or Max Level reached!!");
    }
}
