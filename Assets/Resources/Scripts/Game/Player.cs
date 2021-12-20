using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 50f;
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MovePlayer(Vector2 direction)
    {
        direction.y = 0;
        gameObject.transform.Translate(direction * Time.deltaTime * speed);
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Asteroid")
        {
            LevelManager.Instance().Lose();
        }
        if(collider.gameObject.tag == "EndLevel")
        {
            LevelManager.Instance().Win();
        }
    }
}
