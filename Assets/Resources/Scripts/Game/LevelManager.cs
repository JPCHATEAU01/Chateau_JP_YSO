using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : Singleton<LevelManager>
{
    private PlayerFactory playerFactory;
    private AsteroidFactory asteroidF;
    private List<GameObject> asteroids = new List<GameObject>();
    private List<AsteroidData> asteroidsData = new List<AsteroidData>();
    private GameObject player;
    private GameObject AsteroidsObject;
    private int typePlayer = 0;
    private GameUIManager gameUIManager;
    private int deplacementY = 0;
    private int numberAsteroid = 0;
    private SaveLoadDataIntoJson<Level> levelLoader;
    private Level level;
    private bool isEnded = false;

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
        if(player != null)
        {
            player.GetComponent<Player>().MovePlayer(direction);
        }
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
        asteroids = new List<GameObject>(Resources.LoadAll<GameObject>("Sprites/Asteroids"));
    }

    public void DisplayAsteroids()
    {
        Debug.Log(asteroidsData.Count);
        for(int i = 0; i < asteroidsData.Count; i++)
        {

            AsteroidData asteroid = asteroidsData[i];
            int type = asteroid.GetTypeAsteroid();
            Vector3 pos = asteroid.GetPositionAsteroid();
            float speed = asteroid.GetSpeed();
            ConfigAsteroid(type, pos, speed);
        }
    }
    private void ConfigAsteroid(int numAsteroid, Vector3 pos, float speed = 1f)
    {
        GameObject asteroid = Instantiate(asteroids[numAsteroid], pos, Quaternion.identity, AsteroidsObject.transform);
        asteroid.name = asteroids[0].name + numberAsteroid;
        numberAsteroid++;
        asteroid.GetComponent<Asteroid>().SetSpeed(speed);
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
        SetEnd();
    }

    public void Lose()
    {
        Debug.Log("Lose");
        SetEnd();
    }

    public void SetEnd()
    {
        isEnded = true;
        Time.timeScale = 0;
    }
    public bool IsEnded()
    {
        return isEnded;
    }

    public void LoadLevel(string name)
    {
        levelLoader = new SaveLoadDataIntoJson<Level>("/" + name +".json");
        try
        {
            level = levelLoader.LoadObject();
            asteroidsData = level.GetAsteroids();
        }
        catch (Exception)
        {
            asteroidsData = new List<AsteroidData>();
            asteroidsData.Add(new AsteroidData(0, -2f, 20f, 0, 5f));
            asteroidsData.Add(new AsteroidData(0, 0f, 40f, 0, 5f));
            asteroidsData.Add(new AsteroidData(0, 2f, 60f, 0, 5f));
            level = new Level("error", asteroidsData);
            levelLoader.SaveIntoJson(level);
        }
        DisplayAsteroids();
    }

    public void DiplayLevel(string name)
    {
        isEnded = false;
        DisplayPlayer();
        LoadLevel(name);
    }

}