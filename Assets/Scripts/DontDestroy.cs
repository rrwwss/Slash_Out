using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.STP;

public class DontDestroy : MonoBehaviour
{
    public Slider Slider { get; private set; }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        AudioManager.Instance.PlayClick();
        Slider = GetComponentInChildren<Slider>();
        Slider.value = PlayerPrefs.GetFloat("Volume");
    }
}
