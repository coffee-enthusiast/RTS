using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    NavMeshAgent navAg;
    Vector3 destination;
    bool arrivedToDestination;
    Resource resourceToGather;
    int resourceAmountGathered;
    int maxResourceAmount;

    double startTime;
    double gatherTime;

    string commandAssigned;

    public float breadPerSecond;
    public float temp;
    // Start is called before the first frame update
    void Start()
    {
        navAg = GetComponent<NavMeshAgent>();
        arrivedToDestination = true;
        gatherTime = 1;
        breadPerSecond = 1f / 30f;
        temp = 0;
    }

    private void Update()
    {
        temp += breadPerSecond * Time.deltaTime;
        if (temp >= 1)
        {

            Debug.Log("Eat 1 bread!!");
            if (GameManager.Instance.PayResource(ResourceTag.Bread, 1) == false)
	{
		GameManager.Instance.PayResource(ResourceTag.Unit,1);
                gameObject.SetActive(false);    // Unit Died
}
            temp = 0;
            
            

        }
    }

    public void SetDestination(Vector3 dest)
    {
        destination = dest;
        navAg.SetDestination(dest);
        commandAssigned = "MoveTo";
    }

    public void GatherResource(GameObject resourceObj)
    {
        Debug.Log("Dest: " + resourceObj.transform.position);
        Debug.Log("Reso: " + resourceObj.GetComponent<Resource>().resourceName + " , " + resourceObj.GetComponent<Resource>().resourceAmount);

        resourceToGather = resourceObj.GetComponent<Resource>();
        SetDestination(resourceObj.transform.position);
        commandAssigned = "Gather";
    }


    public void Select()
    {
        if (Utils.SELECTED_UNITS.Contains(this)) return;
        Utils.SELECTED_UNITS.Add(this);
        Debug.Log("Selected: " + gameObject.name);
    }

    public void Deselect()
    {
        if (!Utils.SELECTED_UNITS.Contains(this)) return;
        Utils.SELECTED_UNITS.Remove(this);
        Debug.Log("Deselected: " + gameObject.name);
    }
}
