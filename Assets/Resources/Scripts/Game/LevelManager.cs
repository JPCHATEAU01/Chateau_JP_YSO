using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : Singleton<LevelManager>
{
    private PlayerFactory playerFactory;
    private AsteroidFactory asteroidF;
    private List<GameObject> asteroids = new List<GameObject>();
    private GameObject player;
    public GameObject AsteroidsObject;
    private int typePlayer = 0;
    private GameUIManager gameUIManager;
    private int deplacementY = 0;
    private int numberAsteroid = 0;

    protected override void Awake()
    {
        base.Awake();
        playerFactory = new PlayerFactory();
        asteroidF = new AsteroidFactory();
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

        AsteroidsObject = GameObject.Find("Asteroids");
        asteroids.Add(asteroidF.CreateAsteroid(0));
        ConfigAsteroid(0, new Vector3(-2f, 20f, 0));
        ConfigAsteroid(0, new Vector3(0f, 40f, 0));
        ConfigAsteroid(0, new Vector3(2f, 60f, 0));
    }

    private void ConfigAsteroid(int numAsteroid, Vector3 pos)
    {
        GameObject asteroid = Instantiate(asteroids[numAsteroid], pos, Quaternion.identity, AsteroidsObject.transform);
        asteroid.name = asteroids[0].name + numberAsteroid;
        numberAsteroid++;
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
        gameUIManager.SetLogo(img[typePlayer]);
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
        //Time.timeScale = 0;
    }
}