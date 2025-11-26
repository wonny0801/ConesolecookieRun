using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

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
     

    [Header("Prefab")]
    [SerializeField] private GameObject PlayerPrefab;
    [SerializeField] private GameObject GroundPrefab;
    [SerializeField] private GameObject CoinPrefab;

    [Header("Prefab Spawn Time")]
    [SerializeField] private float gSpawnTime;
    [SerializeField] private float cSpawnTime;
    [SerializeField] private float HpDownTime;

    private Vector3 gSpawnPosition = new Vector3(20f, -4.5f, 0f);
    private Vector3 cSpawnPosition = new Vector3(10f,-3.2f, 0f);

    private float gTimer = 0f;
    private float cTimer = 0f;
    private float HpTimer = 0f;

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
    }

    private void Update()
    {
        gTimer += Time.deltaTime;
        if (gTimer > gSpawnTime)
        {
            SpawnGround();
            gTimer = 0f;
        }
        cTimer += Time.deltaTime;
        if(cTimer > cSpawnTime)
        {
            SpawnCoin();
            cTimer = 0f;
        }
        HpTimer += Time.deltaTime;
        if (HpTimer > HpDownTime)
        {
            HpDown();
            HpTimer = 0f;
        }
        UpdateScoreUI();
        UpdateHpbarUI();
    }

    private void SpawnGround()
    {
        Instantiate(GroundPrefab, gSpawnPosition, Quaternion.identity);
    }
    private void SpawnCoin()
    {
        Instantiate(CoinPrefab,cSpawnPosition, Quaternion.identity);
    }

    private void UpdateScoreUI()
    {
        ScoreText.text = GameScore.ToString();
    }
    private void UpdateHpbarUI()
    {
        hpScrollbar.size = (CurHp / MaxHp);
    }

    private void HpDown()
    {
        if(CurHp > 0)
        {
            Debug.Log("Hp Down");
            CurHp -= 10;
        }
        
    }
}
