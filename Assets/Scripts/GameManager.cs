using TMPro;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Enemy")]
    [SerializeField] private RectTransform enemyHPBar;
    [field: SerializeField] public float EnemyHP { get; private set; }
    [field: SerializeField] public float EnemyAtkPow { get; private set; }

    [Header("Player")]
    [SerializeField] private RectTransform playerHPBar;
    [field: SerializeField] public float PlayerHP { get; private set; }
    [field: SerializeField] public float PlayerAtkPow { get; private set; }

    [Header("ETC")]
    [SerializeField] private CinemachineImpulseSource impulseSource;
    [SerializeField] private Image pauseImage;
    [SerializeField] private TextMeshProUGUI turnScoreText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Image scoreBar;
    [SerializeField] private GameObject turnUp;
    [SerializeField] private GameObject scorePanel;

    private bool _isStopped = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SetScoreUI();
        Time.timeScale = 1;
        EnemyHP = 1920;
        SetPlayerHealth(ScoreManager.Instance.PlayerHPHP);
        Setting();
    }

    public void SetEnemyHealth(float value)
    {
        EnemyHP = value;
        EnemyHP = Mathf.Clamp(EnemyHP, 0, 1920);
        if (EnemyHP == 0)
        {
            SetScene();
        }
        enemyHPBar.sizeDelta = new Vector2(EnemyHP, enemyHPBar.rect.height);
    }

    public void SetPlayerHealth(float value)
    {
        PlayerHP = value;
        PlayerHP = Mathf.Clamp(PlayerHP, 0, 1920);
        if (PlayerHP == 0)
        {
            SceneLoadManager.Instance.LoadGameOverScene();
        }
        playerHPBar.sizeDelta = new Vector2(PlayerHP, playerHPBar.rect.height);
    }

    public void DoImpulse()
    {
        float randValueX = Random.Range(-0.2f, 0.3f);
        float randValueY = Random.Range(-0.2f, 0.3f);
        impulseSource.DefaultVelocity = new Vector3(randValueX, randValueY, 0);
        impulseSource.GenerateImpulse();
    }

    private void SetScene()
    {
        EnemyHP = 1920;
        ScoreManager.Instance.PlayerHPHP = PlayerHP;
        ScoreManager.Instance.PlayerAtkPowPow = PlayerAtkPow;
        ScoreManager.Instance.EnemyAtkPowPow = EnemyAtkPow;
        Setting();
        ScoreManager.Instance.SetScore(ScoreManager.Instance.turnScore);
        SetScoreUI();
        ScoreManager.Instance.SetPlusTurnScore(-ScoreManager.Instance.turnScore);
        turnUp.SetActive(true);
        _isStopped = true;
        Time.timeScale = 0;
    }

    public void Setting()
    {
        PlayerAtkPow = ScoreManager.Instance.PlayerAtkPowPow;
        EnemyAtkPow = ScoreManager.Instance.EnemyAtkPowPow;
    }

    public void SetTurnScoreUI()
    {
        turnScoreText.text = ScoreManager.Instance.turnScore.ToString();
        scoreBar.rectTransform.sizeDelta = new Vector2(scoreBar.rectTransform.rect.width, ScoreManager.Instance.turnScore * 6.25f);
    }

    public void SetScoreUI()
    {
        scoreText.text = ScoreManager.Instance.score.ToString();
    }

    private void OnEscape()
    {
        if (turnUp.activeSelf)
            return;

        if (!_isStopped)
        {
            _isStopped = !_isStopped;
            pauseImage.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            _isStopped = !_isStopped;
            pauseImage.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }
    void Update()
    {
        if (_isStopped || AudioManager.Instance.Config.activeSelf)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
