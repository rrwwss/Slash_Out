using UnityEngine;

public class TestTurnUp : MonoBehaviour
{
    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    private void Update()
    {
        if (gameObject.activeSelf && Time.timeScale != 0)
        {
            Time.timeScale = 0;
        }
    }
}
