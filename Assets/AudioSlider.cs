using UnityEngine;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    Slider _slider;
    private void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.onValueChanged.AddListener(delegate { Slider(); });
    }

    private void Slider()
    {
        AudioManager.Instance.SetVolume();
    }
}
