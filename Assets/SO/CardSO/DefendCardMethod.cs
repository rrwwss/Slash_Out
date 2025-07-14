using UnityEngine;

public class DefendCardMethod : MonoBehaviour, ICardMethod
{
    public void DoCardMethod()
    {
        ScoreManager.Instance.EnemyAtkPowPow -= 20;
        GameManager.Instance.Setting();
    }
}
