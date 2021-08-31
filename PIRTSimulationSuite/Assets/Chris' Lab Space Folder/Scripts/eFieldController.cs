using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eFieldController : MonoBehaviour
{
    public GameObject Vector;
    public Vector3 position;
    public int stepSize = 1;
    public int height = 5;
    public int width = 25;
    public int depth = 5;

    public VectorController launch;

    // Start is called before the first frame update
    void Start()
    {
        position = this.gameObject.transform.position;
        //Instantiation in the X-Direction
        for (int xCount = 0; xCount <= width; xCount++)
        {
            position.y = 1;
            //Instantiation in the y direction
            for (int yCount = 0; yCount <= height; yCount++)
            {
                position.z = -10;
                //Instantiation in the z direction
                for (int zCount = 0; zCount <= depth; zCount++)
                {
                    Instantiate(Vector, position, transform.rotation);
                    position.z+= stepSize;
                }
                position.y+= stepSize;
            }
            position.x+= stepSize;
        }

        launch.startingController();

    }
}
