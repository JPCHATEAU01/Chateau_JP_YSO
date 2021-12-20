using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidFactory
{
    private Object[] asteroids;
    // Start is called before the first frame update
    public AsteroidFactory()
    {
        asteroids = Resources.LoadAll("Sprites/Asteroids", typeof(GameObject));
    }

    public GameObject CreateAsteroid(int numAsteroid)
    {
        if (numAsteroid >= asteroids.Length || numAsteroid < 0)
        {
            numAsteroid = 0;
        }
        return (GameObject)asteroids[numAsteroid];
    }
}
