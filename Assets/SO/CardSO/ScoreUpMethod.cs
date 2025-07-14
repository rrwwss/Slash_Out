using UnityEngine;

public class ScoreUpMethod : MonoBehaviour, ICardMethod
{
    public void DoCardMethod()
    {
        ScoreManager.Instance.PlayerAtkScore++;
    }
}
