using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AsteroidData
{
    [SerializeField] private int type;
    [SerializeField] private float x;
    [SerializeField] private float y;
    [SerializeField] private float z;
    [SerializeField] private float speed;

    public AsteroidData(int type, float x, float y, float z, float speed)
    {
        this.type = type;
        this.x = x;
        this.y = y;
        this.z = z;
        this.speed = speed;
    }

    public int GetTypeAsteroid()
    {
        return type;
    }

    public Vector3 GetPositionAsteroid()
    {
        return new Vector3(x, y, z);
    }

    public float GetSpeed()
    {
        return speed;
    }

}