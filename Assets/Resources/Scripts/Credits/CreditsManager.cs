using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsManager : MonoBehaviour
{
    public void LaunchMenu()
    {
        GameManager.Instance().LaunchScene("MenuScene");
    }
}
