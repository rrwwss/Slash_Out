using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI myScore;

    private void Start()
    {
        myScore = GetComponent<TextMeshProUGUI>();
        ScoreManager.Instance.SetExtraScore();
        myScore.text = PlayerPrefs.GetInt("Score").ToString();
    }
}
