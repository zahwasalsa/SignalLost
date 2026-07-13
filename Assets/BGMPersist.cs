using UnityEngine;

// Tempel script ini di GameObject "BGM" yang ada di scene MainMenu.
// Efeknya: BGM ini akan terus hidup & terus muter walau pindah scene,
// dan kalau scene baru punya BGM sendiri juga, yang baru itu akan dihapus
// (supaya musiknya nggak restart / dobel suara).
public class BGMPersist : MonoBehaviour
{
    // Static = cuma ada 1 "slot" ini yang dipakai bareng semua scene
    public static BGMPersist Instance { get; private set; }

    // Referensi AudioSource di object ini, dipakai buat atur volume dari luar (misal slider)
    public AudioSource audioSource;

    private const string VOLUME_KEY = "bgm_volume";

    private void Awake()
    {
        if (Instance != null)
        {
            // Udah ada BGM yang lagi jalan dari scene sebelumnya -> hapus yang baru
            Destroy(gameObject);
            return;
        }

        // Ini BGM pertama kali muncul -> jadikan instance utama & jangan dihancurkan
        Instance = this;
        DontDestroyOnLoad(gameObject);

        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();

        // Muat volume yang terakhir disimpan (default 1 = 100% kalau belum pernah diatur)
        float savedVolume = PlayerPrefs.GetFloat(VOLUME_KEY, 1f);
        audioSource.volume = savedVolume;
    }

    // Dipanggil dari slider settings buat ubah volume + simpan permanen
    public void SetVolume(float value)
    {
        audioSource.volume = value;
        PlayerPrefs.SetFloat(VOLUME_KEY, value);
    }
}