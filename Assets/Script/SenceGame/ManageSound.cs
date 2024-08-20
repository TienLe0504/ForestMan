using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageSound : MonoBehaviour
{
    public static ManageSound instance;
    [SerializeField] private Slider volumeSlider; // Sử dụng Slider thay vì Image
    private AudioManager audioManager;
    private WinEffect winEffect;
    [SerializeField] private float minVolume = 0f; // Giá trị âm lượng tối thiểu
    [SerializeField] private float maxVolume = 1f; // Giá trị âm lượng tối đa

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Tìm AudioManager nếu nó không tồn tại trong cảnh hiện tại
        if (AudioManager.instance == null)
        {
            AudioManager audioManagerInScene = FindObjectOfType<AudioManager>();
            if (audioManagerInScene != null)
            {
                AudioManager.instance = audioManagerInScene;
                audioManager = audioManagerInScene;
            }
            else
            {
                Debug.LogError("AudioManager not found in the current scene.");
                return;
            }
        }
        else
        {
            audioManager = AudioManager.instance;
        }

        // Tìm WinEffect nếu nó không tồn tại trong cảnh hiện tại
        if (WinEffect.instance == null)
        {
            WinEffect winEffectInScene = FindObjectOfType<WinEffect>();
            if (winEffectInScene != null)
            {
                WinEffect.instance = winEffectInScene;
                winEffect = winEffectInScene;
            }
            else
            {
                Debug.LogError("WinEffect not found in the current scene.");
                return;
            }
        }
        else
        {
            winEffect = WinEffect.instance;
        }

        if (volumeSlider != null)
        {
            volumeSlider.minValue = minVolume;
            volumeSlider.maxValue = maxVolume;
            volumeSlider.onValueChanged.AddListener(OnVolumeSliderValueChanged);

            volumeSlider.value = PlayerPrefs.GetFloat("Volume", audioManager.GetVolume()); // Thiết lập giá trị ban đầu của Slider
            Debug.Log("Slider hoạt động");
        }
        else
        {
            Debug.LogError("Volume slider is not assigned.");
        }
    }

    private void OnVolumeSliderValueChanged(float value)
    {
        SetVolume(value);
    }

    public void SetVolume(float volume)
    {
        if (audioManager != null)
        {
            audioManager.SetVolume(volume);
        }

        if (winEffect != null)
        {
            winEffect.SetVolume(volume);
        }
    }
}
