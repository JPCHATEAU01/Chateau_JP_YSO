using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayNear : MonoBehaviour
{
    public float speed = 1f;
    public GameObject initialObject;
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = initialObject.transform.position;
    }

    void Update()
    {
        transform.Translate(new Vector3(1 * speed * Time.deltaTime, 0, 0));
        if(transform.position.y < -initialObject.gameObject.GetComponent<Renderer>().bounds.size.y)
        {
            transform.position = initialPosition;
        }
    }
}
