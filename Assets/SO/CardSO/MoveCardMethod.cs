using UnityEngine;

public class MoveCardMethod : MonoBehaviour, ICardMethod
{
    public void DoCardMethod()
    {
        ScoreManager.Instance.PlayerMoveAdder += 0.1f;
        GameManager.Instance.Setting();
    }
}
