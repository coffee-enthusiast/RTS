using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{

    public float panSpeed = 20f;
    public float panBorderThickness = 10f;
    public Vector2 panLimit;

    public float scrollSpeed = 20f;
    public float minY = 20f;
    public float maxY = 120f;

    public GameObject building;
    public GameObject buildingSelected;
    public GameObject unitSelected;

    public GameObject pauseMenu;
    bool escapePressed;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Screen.height + " , " + Screen.width);
    }

    void Update()
    {

        Vector3 pos = transform.position;

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            pos.z += panSpeed * Time.deltaTime;
        }

        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            pos.z -= panSpeed * Time.deltaTime;
        }

        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            pos.x += panSpeed * Time.deltaTime;
        }

        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            pos.x -= panSpeed * Time.deltaTime;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y -= scroll * scrollSpeed * 100f * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.z = Mathf.Clamp(pos.z, -panLimit.y, panLimit.y);

        transform.position = pos;


        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.Log(hit.transform.gameObject.name);
                if (hit.transform.gameObject.GetComponent<Unit>())
                    unitSelected = hit.transform.gameObject;
                else
                    unitSelected = null;

                if (hit.transform.gameObject.GetComponent<BuildingUI>())
                {
                    if(buildingSelected != null)
                        buildingSelected.GetComponent<BuildingUI>().Hide();

                    buildingSelected = hit.transform.gameObject;
                    buildingSelected.GetComponent<BuildingUI>().UnHide();
                }
                
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag == "Ground")
                {
                    foreach(Unit u in Utils.SELECTED_UNITS)
                    {
                        u.GetComponent<Unit>().SetDestination(hit.point);
                    }
                    
                    if (unitSelected)
                        unitSelected.GetComponent<Unit>().SetDestination(hit.point);
                    
                }
                if (hit.transform.gameObject.tag == "Resource")
                {
                    if (unitSelected && unitSelected.GetComponent<Gatherer>().resourceCanGather == hit.transform.gameObject.GetComponent<Resource>().resourceTag)
                    {
                        unitSelected.GetComponent<Unit>().SetDestination(hit.point);
                        unitSelected.GetComponent<Gatherer>().AssignResource(hit.transform, hit.transform.gameObject);
                    }
                    foreach (Unit u in Utils.SELECTED_UNITS)
                    {
                        if (u.GetComponent<Gatherer>().resourceCanGather == hit.transform.gameObject.GetComponent<Resource>().resourceTag)
                        {
                            u.GetComponent<Unit>().SetDestination(hit.point);
                            u.GetComponent<Gatherer>().AssignResource(hit.transform, hit.transform.gameObject);
                        }
                    }
                }
            }
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (escapePressed)
            {
                pauseMenu.SetActive(false);
                escapePressed = false;
                Time.timeScale = 1;
            }else
            {

                pauseMenu.SetActive(true);
                escapePressed = true;
                Time.timeScale = 0;
            }
        }
    }
}
