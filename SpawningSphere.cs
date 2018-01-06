using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Dan Florescu
//Mp1
//10/3/17
public class SpawningSphere : MonoBehaviour {

    // new position when clicking on the plane
    Vector3 newPosition;

	// Use this for initialization
	void Start () {
        newPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        // if the left mouse was clicked
        // log the action every time mouse ius clicked to the console 
        // and move the sphere accroding to the mouse click on the plane
		if (Input.GetMouseButtonDown(0)) {
            Debug.Log("left mouse button was clicked");

            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit)) {
                if (hit.collider.tag != "Shape")
                {
                    newPosition = new Vector3(hit.point.x, hit.point.y + 0.25f, hit.point.z);
                    transform.position = newPosition;
                }
            }
        }
	}
}
