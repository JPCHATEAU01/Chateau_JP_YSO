using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFactory
{
    private Object[] ships;

    public PlayerFactory()
    {
        ships = Resources.LoadAll("Sprites/Ships", typeof(GameObject));
    }

    public GameObject CreateShip(int numShip)
    {
        if (numShip >= ships.Length || numShip < 0)
        {
            numShip = 0;
        }
        return (GameObject)ships[numShip];
    }
}
