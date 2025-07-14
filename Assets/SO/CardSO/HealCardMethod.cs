using UnityEngine;

public class HealCardMethod : MonoBehaviour, ICardMethod
{
    public void DoCardMethod()
    {
        ScoreManager.Instance.PlayerHPHP += 400;
        GameManager.Instance.Setting();
        GameManager.Instance.SetPlayerHealth(ScoreManager.Instance.PlayerHPHP);
    }
}
