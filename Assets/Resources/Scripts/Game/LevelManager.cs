using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : Singleton<LevelManager>
{
    private PlayerFactory playerFactory;
    private GameObject player;
    private int typePlayer = 0;
    private GameUIManager gameUIManager;
    private int deplacementY = 1;

    protected override void Awake()
    {
        base.Awake();
        playerFactory = new PlayerFactory();
    }

    void Start()
    {
        
    }

    void Update()
    {

    }

    public void MovePlayer(Vector2 direction)
    {
        player.GetComponent<Player>().MovePlayer(direction);
    }

    public void SetUpTypePlayer(int typePlayer)
    {
        this.typePlayer = typePlayer;
    }

    public void DisplayPlayer()
    {
        player = playerFactory.CreateShip(typePlayer);
        player.name = "player";
        GameObject shipParent = GameObject.Find("Ship");
        player = Instantiate(player, shipParent.transform);
        player.GetComponent<Player>().SetDeplacementY(deplacementY);
    }

    public void SetGameUIManager(GameUIManager gameUIManager)
    {
        this.gameUIManager = gameUIManager;
    }

    public void SetHandleImage()
    {
        Sprite[] img = Resources.LoadAll<Sprite>("Sprites/Logo"); 
        Resources.LoadAll("Sprites/Logo", typeof(Sprite));
        if(typePlayer >= img.Length)
        {
            typePlayer = 0;
        }
        gameUIManager.SetHandle(img[typePlayer]);
    }

    public void SetDeplacement(int deplacementY)
    {
        this.deplacementY = deplacementY;
    }

    public void Win()
    {
        Debug.Log("Win");
        Time.timeScale = 0;
    }

    public void Lose()
    {
        Debug.Log("Lose");
        Time.timeScale = 0;
    }
}