using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 50f;
    private int deplacementY = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDeplacementY(int deplacementY)
    {
        Debug.Log(deplacementY);
        this.deplacementY = deplacementY;
    }

    public void MovePlayer(Vector2 direction)
    {
        if (deplacementY == 0)
        {
            direction.y = 0;
        }
        Vector3 moveRotate = new Vector3(direction.x, 0, direction.y);
        gameObject.transform.Translate(moveRotate * Time.deltaTime * speed);
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
