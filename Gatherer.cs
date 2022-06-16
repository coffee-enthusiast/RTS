using System.Collections;
using UnityEngine;

public class Gatherer : MonoBehaviour
{

    public Transform gatheringPosition;
    public GameObject resourceGO;
    public Resource resourceToGather;
    public ResourceTag resourceCanGather;

    float amountPerSecond;
    public float amountCollected;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (resourceToGather != null)
        {
            amountCollected += amountPerSecond * Time.deltaTime;
            if (amountCollected >= 1)
            {
                if (resourceToGather.TakeResource() == 1)
                {
                    Debug.Log("Collected 1 " + resourceCanGather + "unit!!");
                    GameManager.Instance.AddResource(resourceCanGather);
                    amountCollected = 0;
                }
                else
                    Destroy(resourceGO);

            }
        }
    }

    public void AssignResource(Transform t, GameObject r)
    {
        resourceGO = r;
        resourceToGather = r.GetComponent<Resource>();
        if(resourceToGather.resourceType == ResourceType.Collected && resourceToGather.resourceTag == resourceCanGather)
        {
            amountPerSecond = 1f / resourceToGather.unitTime;
        }
    }
}
