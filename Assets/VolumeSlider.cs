using UnityEngine;
using UnityEngine.UI;

// Tempel script ini di GameObject Slider volume musik (di panel Settings).
public class VolumeSlider : MonoBehaviour
{
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();

        // Set posisi slider sesuai volume yang lagi aktif saat ini
        if (BGMPersist.Instance != null)
        {
            slider.value = BGMPersist.Instance.audioSource.volume;
        }

        // Setiap slider digeser, panggil fungsi OnSliderChanged
        slider.onValueChanged.AddListener(OnSliderChanged);
    }

    private void OnSliderChanged(float value)
    {
        if (BGMPersist.Instance != null)
        {
            BGMPersist.Instance.SetVolume(value);
        }
    }
}