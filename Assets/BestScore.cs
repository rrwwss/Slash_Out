using TMPro;
using UnityEngine;

public class BestScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bestScore;

    private void Start()
    {
        bestScore = GetComponent<TextMeshProUGUI>();
        PlayerPrefs.SetInt("BestScore", ScoreManager.Instance._bestScore);
        bestScore.text = PlayerPrefs.GetInt("BestScore").ToString();
    }
}
