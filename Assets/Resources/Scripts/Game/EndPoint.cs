using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{

    private float speed = 1f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(new Vector3(0, -1 * speed * Time.deltaTime, 0));

    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}
