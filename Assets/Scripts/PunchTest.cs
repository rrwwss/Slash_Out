using UnityEngine;
using UnityEngine.Events;

public class PunchTest : MonoBehaviour
{
    [SerializeField] private float attackPower;
    public UnityEvent OnAtkedByPlayer;
    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            OnAtkedByPlayer?.Invoke();
            AudioManager.Instance.PlaySlash();
            ScoreManager.Instance.SetPlusTurnScore(ScoreManager.Instance.PlayerAtkScore);
            attackPower = GameManager.Instance.PlayerAtkPow;
            GameManager.Instance.SetEnemyHealth(GameManager.Instance.EnemyHP - attackPower);
        }
    }
}
