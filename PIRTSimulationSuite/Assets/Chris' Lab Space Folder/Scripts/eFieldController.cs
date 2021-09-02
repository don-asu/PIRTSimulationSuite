using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eFieldController : MonoBehaviour
{
    public GameObject Vector;
    public Transform spawnPoint;
    public Vector3 position;
    public int stepSize = 1;
    public int height = 10;
    public int width = 10;
    public int depth = 10;

    public VectorController launch;

    // Start is called before the first frame update
    void Start()
    {
        position = spawnPoint.transform.position;
        
        //Instantiation in the X-Direction
        for (int xCount = 0; xCount <= width; xCount++)
        {
            position.y = spawnPoint.transform.position.y;
            //Instantiation in the y direction
            for (int yCount = 0; yCount <= height; yCount++)
            {
                position.z = spawnPoint.transform.position.z;
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
