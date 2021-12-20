using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EndPointData
{
    [SerializeField] private float y;
    [SerializeField] private float speed;

    public EndPointData( float y, float speed)
    {
        this.y = y;
        this.speed = speed;
    }

    public float GetPosition()
    {
        return y;
    }

    public float GetSpeed()
    {
        return speed;
    }
}
