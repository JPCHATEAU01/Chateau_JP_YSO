using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 0.1f;
    private int deplacementY = 0;
    private ParticleSystem explosion;
    void Start()
    {
        explosion = Resources.Load<ParticleSystem>("Sprites/Prefabs/Explosion");
    }

    void Update()
    {
        
    }

    public void SetDeplacementY(int deplacementY)
    {
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
            SetExplosion();
            LevelManager.Instance().Lose();
            Destroy(collider.gameObject);
            Destroy(gameObject);
        }
        if(collider.gameObject.tag == "EndPoint")
        {
            LevelManager.Instance().Win();
        }
    }

    void SetExplosion()
    {
        explosion = Instantiate(explosion, transform.parent);
        explosion.transform.position = transform.position;
        explosion.Stop();
        explosion.Play();
        Destroy(explosion, explosion.main.duration);
    }

}