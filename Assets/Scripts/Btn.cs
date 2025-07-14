using UnityEngine;
using UnityEngine.UI;

public class Btn : MonoBehaviour
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
        AudioManager.Instance.SliderActive(true);
    }
}
