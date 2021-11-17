using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoor : MonoBehaviour
{

    public Transform startPosition;
    public Transform endPosition;

    public bool doorUp = false;
    public bool doorDown = false;

    public float t = 0.02f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (doorUp)
        {
            MoveDoorUp();
        }

        if (doorDown)
        {
            MoveDoorDown();
        }
    }
    public void ToggleDoorUp()
    {
        if (doorDown == true)
        {
            doorDown = false;
        }
        doorUp = true;
    }

    public void MoveDoorUp()
    {
        
        transform.position = Vector3.Lerp(transform.position, endPosition.position, t);
        if (transform.position == endPosition.position)
        {
            doorUp = false;
        }
    }

    public void ToggleDoorDown()
    {
        if (doorUp == true)
        {
            doorUp = false;
        }
        doorDown = true;
    }

    public void MoveDoorDown()
    {

        transform.position = Vector3.Lerp(transform.position, startPosition.position, t);
        if (transform.position == startPosition.position)
        {
            doorDown = false;
        }
        
    }
}
