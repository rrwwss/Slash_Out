using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [field : SerializeField] public int turnScore { get; private set; }
    [field : SerializeField] public int maxTurnScore { get; private set; }
    [field : SerializeField] public int score { get; private set; }

    [field: SerializeField] public float PlayerHPHP { get; set; } = 1920;
    [field: SerializeField] public float PlayerAtkPowPow { get; set; } = 100;
    [field: SerializeField] public float EnemyAtkPowPow { get; set; } = 150;
    [field: SerializeField] public int PlayerAtkScore { get; set; } = 2;
    [field: SerializeField] public int PlayerMoveScore { get; set; } = 1;
    [field: SerializeField] public int EnemyAtkScore { get; set; } = 1;
    [field: SerializeField] public float PlayerMoveAdder { get; set; } = 0;

    public int _bestScore;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetScore(int value)
    {
        score += value;
        PlayerPrefs.SetInt("Score", score);
        if (score > _bestScore)
        {
            _bestScore = score;
        }
    }

    public void SetExtraScore()
    {
        PlayerPrefs.SetInt("Score", score + turnScore);
        if (score+turnScore > _bestScore)
        {
            _bestScore = score;
        }
    }

    public void SetPlusTurnScore(int value)
    {
        turnScore += value;
        turnScore = Mathf.Clamp(turnScore, 0, maxTurnScore);
        GameManager.Instance.SetTurnScoreUI();
    }

    public void ResetInstance()
    {
        if (Instance != null)
        {
            Destroy(Instance.gameObject);
            Instance = null;
        }

        GameObject newManager = new GameObject("GameManager");
        newManager.AddComponent<GameManager>();
    }
}
