using System;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class GameMng : MonoBehaviour
{
    public static GameMng instance {  get; private set; }
    public static int GameScore { get; set; } = 0;
    public static int PlusScoreValue { get; set; } = 10;
    public static float MaxHp { get; set; } = 300.0f;
    public static float CurHp { get; set; } = 300.0f;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI ScoreText;
    [SerializeField] private Scrollbar hpScrollbar;
    [SerializeField] private GameObject GameOverUI;
    [SerializeField] private TextMeshProUGUI GameOverScoreText;
    [SerializeField] private Button RestartButton;


    [Header("Prefab")]
    [SerializeField] private GameObject PlayerPrefab;
    [SerializeField] private GameObject GroundPrefab;
    [SerializeField] private GameObject CoinPrefab;
    [SerializeField] private GameObject EnemyPrefab1;

    [Header("Prefab Spawn Time")]
    [SerializeField] private float gSpawnTime;
    [SerializeField] private float cSpawnTime;
    [SerializeField] private float e1SpawnTimeMax;
    [SerializeField] private float HpDownTime;

    private Vector3 gSpawnPosition = new Vector3(20f, -4.5f, 0f);
    private Vector3 cSpawnPosition = new Vector3(10f,-3.6f, 0f);
    private Vector3 eSpawnPosition = new Vector3(10f, -0.75f, 0f);

    private float gTimer = 0f;
    private float cTimer = 0f;
    private float e1Timer = 0f;
    private float HpTimer = 0f;

    private float e1SpawnTime = 0f;

    private void Awake()
    {
        Debug.Log("start");
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        Debug.Log("start1");
        Instantiate(PlayerPrefab, new Vector3(-7f, -3f, 0f), Quaternion.identity);
        Instantiate(GroundPrefab, new Vector3(0f,-4.5f,0f),Quaternion.identity);
        SpawnGround();
        hpScrollbar.enabled = true;
        hpScrollbar.size = 1.0f;
        GameOverUI.SetActive(false);
        Init();

        RestartButton.onClick.AddListener(Restart);
    }
    private void Init()
    {
        GameScore = 0;
        PlusScoreValue = 10;
        MaxHp = 300f;
        CurHp = 300f;
        Time.timeScale = 1.0f;
    }

    private void Update()
    {
        SpawnGroundUpdate();
        SpawnCoinUpdate();
        SpawnEnemy1Update();
        HpUpdate();
  
        UpdateScoreUI();
        UpdateHpbarUI();

        if (CurHp <= 0)
            GameOver();
        
    }

    private void SpawnGround()
    {
        Instantiate(GroundPrefab, gSpawnPosition, Quaternion.identity);
    }
    private void SpawnCoin()
    {
        Instantiate(CoinPrefab,cSpawnPosition, Quaternion.identity);
    }
    private void SpawnEnemy1()
    {
        Instantiate(EnemyPrefab1,eSpawnPosition, Quaternion.identity);
    }
    private void HpDown()
    {
        if (CurHp > 0)
        {
            Debug.Log("Hp Down");
            CurHp -= 10;
        }
    }
    private void SpawnGroundUpdate()
    {
        gTimer += Time.deltaTime;
        if (gTimer > gSpawnTime)
        {
            SpawnGround();
            gTimer = 0f;
        }
    }
    private void SpawnCoinUpdate()
    {
        cTimer += Time.deltaTime;
        if (cTimer > cSpawnTime)
        {
            SpawnCoin();
            cTimer = 0f;
        }
    }
    private void SpawnEnemy1Update()
    {
        e1Timer += Time.deltaTime;
        if(e1Timer > e1SpawnTime)
        {
            SpawnEnemy1();
            e1Timer = 0f;
            e1SpawnTime = (float)UnityEngine.Random.Range(1.5f,e1SpawnTime);
        }
    }
    private void HpUpdate()
    {
        HpTimer += Time.deltaTime;
        if (HpTimer > HpDownTime)
        {
            HpDown();
            HpTimer = 0f;
        }
    }
    private void UpdateScoreUI()
    {
        ScoreText.text = GameScore.ToString();
    }
    private void UpdateHpbarUI()
    {
        hpScrollbar.size = (CurHp / MaxHp);
    }
    private void GameOver()
    {
        Time.timeScale = 0f;
        GameOverUI.SetActive(true);
        GameOverScoreText.text = "Score : " + GameScore.ToString();
    }
    public void Restart()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
