using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [field: SerializeField] public float Volume { get; private set; }
    [field: SerializeField] public AudioSource Source { get; set; }
    [field: SerializeField] public AudioClip Slash { get; set; }
    [field: SerializeField] public AudioClip Click { get; set; }
    [field: SerializeField] public AudioClip Block { get; set; }

    [field : SerializeField] public Slider Slider { get; set; }
    [SerializeField] private GameObject prefab;

    public static AudioManager Instance { get; private set; }
    [SerializeField] public GameObject Config { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Slider == null)
        {
            Config = Instantiate(prefab);
            Slider = Config.GetComponentInChildren<Slider>();
        }
    }

    public void SliderActive(bool value)
    {
        Config.SetActive(value);
    }

    public void SetVolume()
    {
        Volume = Slider.value;
        PlayerPrefs.SetFloat("Volume", Volume);
    }

    public void PlaySlash()
    {
        Source.PlayOneShot(Slash, Volume);
    }

    public void PlayClick()
    {
        Source.PlayOneShot(Click, Volume);
    }

    public void PlayBlock()
    {
        Source.PlayOneShot(Block, Volume);
    }
}
