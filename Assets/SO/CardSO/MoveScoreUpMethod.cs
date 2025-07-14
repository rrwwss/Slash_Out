using UnityEngine;

public class MoveScoreUpMethod : MonoBehaviour, ICardMethod
{
    public void DoCardMethod()
    {
        ScoreManager.Instance.PlayerMoveScore++;
    }
}
