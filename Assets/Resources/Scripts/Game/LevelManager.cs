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
    private SaveLoadDataIntoJsonFromResources<Level> levelLoader;
    private Level level;
    private GameObject endPoint;
    private EndPointData endPointData;
    private bool isEnded = false;
    private float endpoitStart;

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
        if (!isEnded && gameUIManager != null)
        {
            gameUIManager.UpdateSlider(endpoitStart - endPoint.transform.position.y, endpoitStart);//player.transform.position.y,
        }
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
    }

    public void DisplayAsteroids()
    {
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

    private void ConfigEndPoint()
    {
        GameObject endPointParent = GameObject.Find("EndPoint");
        Vector3 pos = new Vector3(0f, endPointData.GetPosition(), 0f);
        endPoint = Instantiate(endPoint, pos, Quaternion.identity, endPointParent.transform);
        endPoint.GetComponent<EndPoint>().SetSpeed(endPointData.GetSpeed());
        endpoitStart = endPoint.transform.position.y;
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
        SetEnd(true);
    }

    public void Lose()
    {
        SetEnd(false);
    }

    public void SetEnd(bool isVictory)
    {
        isEnded = true;
        StartCoroutine(Wait(isVictory));
        //Time.timeScale = 0;
    }

    public bool IsEnded()
    {
        return isEnded;
    }

    public void LoadLevel(string name)
    {
        levelLoader = new SaveLoadDataIntoJsonFromResources<Level>(name);
        try
        {
            level = levelLoader.LoadObject();
            asteroidsData = level.GetAsteroids();
            endPointData = level.GetEndPoint();
        }
        catch (Exception)
        {
            Debug.Log("ERROR ");
            /*asteroidsData = new List<AsteroidData>();
            asteroidsData.Add(new AsteroidData(1, -2f, 20f, 0, 5f));
            asteroidsData.Add(new AsteroidData(1, -1f, 25f, 0, 5f));
            asteroidsData.Add(new AsteroidData(1, 0f, 30f, 0, 5f));
            asteroidsData.Add(new AsteroidData(1, 1f, 35f, 0, 5f));
            asteroidsData.Add(new AsteroidData(1, 2f, 40f, 0, 5f));
            asteroidsData.Add(new AsteroidData(1, 1f, 45f, 0, 5f));
            asteroidsData.Add(new AsteroidData(1, 0f, 50f, 0, 5f));
            asteroidsData.Add(new AsteroidData(1, -1f, 55f, 0, 5f));
            asteroidsData.Add(new AsteroidData(1, -2f, 60f, 0, 5f));
            asteroidsData.Add(new AsteroidData(1, -2f, 70f, 0, 5f));
            asteroidsData.Add(new AsteroidData(1, -1f, 70f, 0, 5f));
            asteroidsData.Add(new AsteroidData(1, 0f, 70f, 0, 5f));
            asteroidsData.Add(new AsteroidData(1, 1f, 70f, 0, 5f));
            endPointData = new EndPointData(110f, 5f);
            level = new Level("level2", asteroidsData, endPointData);
            levelLoader.SaveIntoJson(level);*/
        }
        DisplayAsteroids();
        ConfigEndPoint();
    }

    public void DiplayLevel(string name)
    {
        isEnded = false;
        AsteroidsObject = GameObject.Find("Asteroids");
        asteroids = new List<GameObject>(Resources.LoadAll<GameObject>("Sprites/Asteroids"));
        endPoint = Resources.Load<GameObject>("Sprites/EndPoint/EndLevel");
        DisplayPlayer();
        LoadLevel(name);
    }

    IEnumerator Wait(bool isVictory)
    {
        yield return new WaitForSeconds(2f);
        gameUIManager.End(isVictory);
    }

}