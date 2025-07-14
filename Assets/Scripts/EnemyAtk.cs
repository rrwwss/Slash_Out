using UnityEngine;
using UnityEngine.Events;

public class EnemyAtk : MonoBehaviour
{
    [SerializeField] private float attackPower;
    [SerializeField] private UnityEvent OnBonus;
    public UnityEvent OnAtkedByEnemy;

    private void Start()
    {
        attackPower = GameManager.Instance.EnemyAtkPow;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.Instance.PlaySlash();
            OnAtkedByEnemy?.Invoke();
            ScoreManager.Instance.SetPlusTurnScore(-ScoreManager.Instance.EnemyAtkScore);
            GameManager.Instance.SetPlayerHealth(GameManager.Instance.PlayerHP - attackPower);
            ScoreManager.Instance.PlayerHPHP = GameManager.Instance.PlayerHP;
        }

        if (collision.CompareTag("Bonus"))
        {
            AudioManager.Instance.PlayBlock();
            ScoreManager.Instance.SetPlusTurnScore(ScoreManager.Instance.PlayerMoveScore);
            OnBonus?.Invoke();
        }
    }
}
