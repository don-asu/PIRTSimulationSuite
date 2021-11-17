using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnHit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision happened with " + collision);
        gameObject.GetComponent<AudioSource>().Play();
    }

    //private void ontriggerenter(collider other)
    //{
    //    debug.log("collision happened with " + other);
    //    other.gameobject.getcomponent<audiosource>().play();
    //}
}
