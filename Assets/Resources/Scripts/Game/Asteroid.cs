using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private float speed = 1f;
    private bool isprevent = false;
    private GameObject prevent;

    void Start()
    {

    }

    void Update()
    {
        if(transform.position.y > 10 && transform.position.y < 15)
        {
            if (!isprevent)
            {
                isprevent = true;
                Prevent();
            }
        }

        if (transform.position.y > 4 && transform.position.y < 8)
        {
            DestroyPrevent();
        }
            //transform.Rotate(Vector3.left * speed * Time.deltaTime);
            //transform.Rotate(Vector3.right * speed * Time.deltaTime);
            //transform.Rotate(Vector3.up * speed * Time.deltaTime);
            //transform.Rotate(Vector3.down * speed * Time.deltaTime);
            //transform.Rotate(Vector3.forward * speed * Time.deltaTime);
            transform.Translate(new Vector3(0, -1 * speed * Time.deltaTime, 0));

        if (transform.position.y < -20)
        {
            Destroy(this.gameObject);
        }
    }

    public void Prevent()
    {
        GameObject alert = GameObject.CreatePrimitive(PrimitiveType.Cube);
        alert.GetComponent<BoxCollider>().enabled = false;
        alert.transform.Rotate(90, 0, 0);
        Vector3 scaleChange = new Vector3(gameObject.transform.localScale.x, 1, 1);
        alert.transform.localScale = scaleChange;
        alert.transform.position = new Vector3(gameObject.transform.position.x, 5.37f, 0);
        alert.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 1);
        prevent = alert;
    }

    public void DestroyPrevent()
    {
        if(prevent != null)
        {
            Destroy(prevent);
        }
    }

    public void OnDestroy()
    {
        DestroyPrevent();
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}