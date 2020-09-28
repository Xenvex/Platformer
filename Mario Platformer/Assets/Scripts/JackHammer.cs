using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackHammer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Test for mouse click
        if (Input.GetMouseButtonUp(0))
        {
            //et mouse position in world space
            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100f));

            //Get direction vector from camera position to m ouse position in world space
            Vector3 direction = worldMousePosition - Camera.main.transform.position;

            RaycastHit hit;

            // Cast a ray from the camera to the given direction
            if (Physics.Raycast(Camera.main.transform.position, direction, out hit, 100f))
            {
                Debug.Log(hit.collider.gameObject.name);
                //If it hits a brick
                if (hit.collider.gameObject.name == "Brick(Clone)")
                {

                    Destroy(hit.collider.gameObject);
                }

                //If it hits a question mark box
                if (hit.collider.gameObject.name == "Question Box(Clone)")
                {
                    Destroy(hit.collider.gameObject);
                }


            }

        }
    }
}
