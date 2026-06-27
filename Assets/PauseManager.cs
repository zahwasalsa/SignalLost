using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [Header("Referensi UI")]
    [Tooltip("Panel yang muncul saat game di-pause (boleh dikosongkan kalau cuma mau pause logic tanpa UI panel)")]
    public GameObject pausePanel;
 
    [Header("Nama Scene Main Menu (untuk tombol Quit)")]
    public string mainMenuSceneName = "MainMenu";
 
    private bool _isPaused = false;
    public bool IsPaused => _isPaused;
 
    /// <summary>
    /// Dipanggil dari tombol ButtonPause. Toggle antara pause <-> resume.
    /// </summary>
    public void TogglePause()
    {
        if (_isPaused) Resume();
        else Pause();
    }
 
    public void Pause()
    {
        _isPaused = true;
        Time.timeScale = 0f; // freeze semua gerakan & timer yang pakai Time.deltaTime
        if (pausePanel != null) pausePanel.SetActive(true);
    }
 
    public void Resume()
    {
        _isPaused = false;
        Time.timeScale = 1f;
        if (pausePanel != null) pausePanel.SetActive(false);
    }
 
    /// <summary>
    /// Dipanggil dari tombol Quit di dalam Pause Panel, balik ke Main Menu.
    /// </summary>
    public void QuitToMenu()
    {
        Time.timeScale = 1f; // penting: reset timescale sebelum pindah scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(mainMenuSceneName);
    }
}