using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour
{
    Button _btn;
    private void Start()
    {
        _btn = GetComponent<Button>();
        _btn.onClick.AddListener(Btnn);
    }

    private void Btnn()
    {
        AudioManager.Instance.PlayClick();
    }
}
