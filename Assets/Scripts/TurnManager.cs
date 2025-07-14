using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public static TurnManager Instance { get; private set; }
    public int Turn { get; private set; } = 0;

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

    public void ResetInstance()
    {
        if (Instance != null)
        {
            Destroy(Instance.gameObject);
            Instance = null;
        }

        GameObject newManager = new GameObject("TurnManager");
        newManager.AddComponent<GameManager>();
    }

    public void TurnValueUp()
    {
        Turn++;
        ScoreManager.Instance.PlayerAtkPowPow -= 20;
        ScoreManager.Instance.EnemyAtkPowPow += 5;
        ScoreManager.Instance.EnemyAtkScore++;
    }
}
