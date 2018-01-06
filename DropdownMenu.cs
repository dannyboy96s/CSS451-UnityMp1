using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

//Dan Florescu
//Mp1
//10/3/17
public class DropdownMenu : MonoBehaviour {

    //reference the dropdown
    public Dropdown dropdown;   

    //prefab
    public GameObject cube;
    public GameObject sphere;
    public GameObject cylinder;

    public float speed = 1.0F;

    //list for dropdown menu
    List<string> objects = new List<string>() { "Object to create", "Sphere", "Cube", "Cylinder" };


    // Use this for initialization
    void Start () {
        populateDropdownMenu();
	}
	
	// Update is called once per frame
	void Update () {
        
        clickToDestroyPrefabs();

        GameObject pos = GameObject.Find("Sphere");
        Transform objTransform = pos.transform;
        //get the initial sphere position
        Vector3 position = objTransform.position;
        //switch between the dropdown values and instantiate the objects
        //Ignore case 0, case 1 for creating sphere, case 2 for creating a cube, case 3 for creating a cylinder
        switch (dropdown.value)
        {
            case 1:
                GameObject sphereInstance = Instantiate(sphere, position, transform.rotation);
                dropdown.value = 0;
                break;
            case 2:
                GameObject cubeInstance = Instantiate(cube, position, transform.rotation);
                dropdown.value = 0;
                break;
            case 3:
                GameObject cylinderInstance = Instantiate(cylinder, position, transform.rotation);
                dropdown.value = 0;
                break;
        }

        
    }

    //Will populate the drop down menu from the list of items
    void populateDropdownMenu() {    
        dropdown.AddOptions(objects);
    }

    //Right click to only destroy the prefabs created.
    //Check to see if it indeed is a prefab and if it is, destroy the object.
    void clickToDestroyPrefabs() {
        if(Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                if (hit.collider.tag != "Shape")
                {
                    return;
                }

                if (hit.collider.gameObject.name == "SpherePrefab(Clone)" || hit.collider.gameObject.name == "CubePrefab(Clone)" || hit.collider.gameObject.name == "CylinderPrefab(Clone)") {
                    Destroy(hit.collider.gameObject);
                }                
            }
        }
    }
}
