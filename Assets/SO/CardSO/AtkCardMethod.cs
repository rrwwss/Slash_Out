using UnityEngine;

public class AtkCardMethod : MonoBehaviour, ICardMethod
{
    public void DoCardMethod()
    {
        ScoreManager.Instance.PlayerAtkPowPow += 30;
        GameManager.Instance.Setting();
    }
}
