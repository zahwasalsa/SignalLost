using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Pasang script ini di GameObject "TutorialPanel".
/// Isi list "pages" di Inspector dengan teks tiap halaman tutorial.
/// Hubungkan tombol Next, Back, Close, dan Text (TMP) untuk menampilkan isi halaman.
/// </summary>
public class TutorialManager : MonoBehaviour
{
    [Header("Konten Tutorial (isi teks tiap halaman di sini)")]
    [TextArea(3, 6)]
    public string[] pages = new string[]
    {
        "Kamu terjebak di Kota Robot.\nKumpulkan Energy Core yang tersebar untuk membuka jalan keluar.\nHati-hati, kota ini menyimpan bahaya — bergeraklah dengan cermat!"
    };

    [Header("UI References")]
    public TMP_Text contentText;     // Text (TMP) yang menampilkan isi halaman
    public GameObject tutorialPanel; // Panel induk tutorial (untuk dibuka/tutup)
    public Button nextButton;
    public Button backButton;
    public TMP_Text pageIndicatorText; // opsional, contoh: "1 / 3"

    private int currentPage = 0;

    void OnEnable()
    {
        currentPage = 0;
        UpdatePage();
    }

    public void OpenTutorial()
    {
        tutorialPanel.SetActive(true);
        currentPage = 0;
        UpdatePage();
    }

    public void CloseTutorial()
    {
        tutorialPanel.SetActive(false);
    }

    public void NextPage()
    {
        if (currentPage < pages.Length - 1)
        {
            currentPage++;
            UpdatePage();
        }
        else
        {
            CloseTutorial(); // di halaman terakhir, Next jadi tombol selesai
        }
    }

    public void PreviousPage()
    {
        if (currentPage > 0)
        {
            currentPage--;
            UpdatePage();
        }
    }

    private void UpdatePage()
    {
        if (pages.Length == 0) return;

        contentText.text = pages[currentPage];

        if (pageIndicatorText != null)
            pageIndicatorText.text = (currentPage + 1) + " / " + pages.Length;

        if (backButton != null)
            backButton.gameObject.SetActive(currentPage > 0);

        if (nextButton != null)
        {
            var btnText = nextButton.GetComponentInChildren<TMP_Text>();
            if (btnText != null)
                btnText.text = (currentPage == pages.Length - 1) ? "Selesai" : "Lanjut";
        }
    }
}