using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{

    private float lenghtOfGround;
    private float startPosition;
    public GameObject camera;
    public float speed;


    void Start()
    {
        startPosition = transform.position.x;
        lenghtOfGround = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    void Update()
    {
        float temp = (camera.transform.position.x * (1 - speed));
        float distance = (camera.transform.position.x * speed);

        transform.position = new Vector3(startPosition + distance, transform.position.y, transform.position.z);

        if (temp > startPosition + lenghtOfGround) startPosition += lenghtOfGround;
        else if (temp < startPosition - lenghtOfGround) startPosition -= lenghtOfGround;
    }
}
