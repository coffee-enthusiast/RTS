using UnityEngine;
using System.Collections;

public enum ResourceType
{
    Collected,
    Produced
}
public enum ResourceTag
{
    Wood,
    Gold,
    Rock,
    Bread,
    Unit
}

public class Resource : MonoBehaviour
{

    public string resourceName;
    public ResourceType resourceType;
    public ResourceTag resourceTag;
    public int resourceAmount;
    public float unitTime;

    public int TakeResource()
    {
        if (resourceAmount >= 1)
        {
            resourceAmount--;
            return 1;
        }
        else
        {
            Destroy(this);
            return 0;
        }
    }

}
