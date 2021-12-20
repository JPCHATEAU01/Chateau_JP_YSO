using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Level
{
    [SerializeField] private string name;
    [SerializeField] private List<AsteroidData> asteroids;

    public Level(string name, List<AsteroidData> asteroids)
    {
        this.name = name;
        this.asteroids = asteroids;
    }

    public string GetName()
    {
        return name;
    }

    public List<AsteroidData> GetAsteroids()
    {
        return asteroids;
    }

}