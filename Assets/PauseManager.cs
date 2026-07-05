using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [Header("Referensi UI")]
    public GameObject pausePanel;

    [Header("Nama Scene Main Menu (untuk tombol Quit)")]
    public string mainMenuSceneName = "MainMenu";

    private bool _isPaused = false;
    public bool IsPaused => _isPaused;

    private void Update()
    {
        // Tekan Escape untuk pause/resume — bypass masalah klik UI
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if (_isPaused) Resume();
        else Pause();
    }

    public void Pause()
    {
        _isPaused = true;
        Time.timeScale = 0f;
        if (pausePanel != null) pausePanel.SetActive(true);

        // Unlock cursor biar bisa klik tombol Resume/Quit di panel
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Resume()
    {
        _isPaused = false;
        Time.timeScale = 1f;
        if (pausePanel != null) pausePanel.SetActive(false);

        // Lock cursor lagi biar balik ke mode gameplay
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void QuitToMenu()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene(mainMenuSceneName);
    }
}