using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [Header("Panel References")]
    public GameObject panelGameOver;   // drag PanelGameOver dari Canvas ke sini

    [Header("State")]
    private bool isGameOver = false;

    void Start()
    {
        // Pastikan panel gagal tersembunyi saat game dimulai
        if (panelGameOver != null)
            panelGameOver.SetActive(false);
    }

    // Panggil method ini dari Timer.cs saat waktu mencapai 0
    public void TriggerGameOver()
    {
        if (isGameOver) return; // supaya tidak double-trigger

        isGameOver = true;

        // Tampilkan panel "Signal Lost"
        if (panelGameOver != null)
            panelGameOver.SetActive(true);

        // Hentikan waktu di game (mirip logic PauseManager)
        Time.timeScale = 0f;

        // Unlock cursor supaya bisa klik tombol Restart / Menu
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Hubungkan ke tombol "Retry" di panel gagal
    public void RestartLevel()
    {
        Time.timeScale = 1f; // reset dulu sebelum reload scene
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Hubungkan ke tombol "Main Menu" di panel gagal
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("MainMenu"); // sesuaikan nama scene menu kamu
    }

    // Cek apakah game sudah dalam kondisi gagal (opsional, buat script lain)
    public bool IsGameOver()
    {
        return isGameOver;
    }
}