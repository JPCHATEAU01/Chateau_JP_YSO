using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T :Singleton<T>
{
    private static T instance;

    private void Awake()
    {
        if (instance != null && instance != this as T)
            Destroy(gameObject);
        else
        {
            instance = this as T;
            DontDestroyOnLoad(transform.gameObject);
        }
    }

    public static T Instance()
    {
        return instance;
    }

}
