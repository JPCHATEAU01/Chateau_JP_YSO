using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Level
{
    [SerializeField] private string name;
    [SerializeField] private List<AsteroidData> asteroids;
    [SerializeField] private EndPointData endPoint;

    public Level(string name, List<AsteroidData> asteroids, EndPointData endPoint)
    {
        this.name = name;
        this.asteroids = asteroids;
        this.endPoint = endPoint;
    }

    public string GetName()
    {
        return name;
    }

    public List<AsteroidData> GetAsteroids()
    {
        return asteroids;
    }

    public EndPointData GetEndPoint()
    {
        return endPoint;
    }

}