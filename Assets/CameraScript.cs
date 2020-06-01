using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    private Transform dinoTransform;

    public float camOffset;
   
    void Start()
    {
        dinoTransform = GameObject.Find("Dino").transform;
    }

   
    void Update()
    {
        Vector3 temp = transform.position;

        temp.x = dinoTransform.position.x;

        temp.x += camOffset;

        transform.position = temp;
    }
}
