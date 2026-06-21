using TMPro;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    public static CollectibleManager Instance;

    public TextMeshProUGUI energyText;

    private int currentCore = 0;
    public int totalCore = 4;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateUI();
    }

    public void AddCore()
    {
        currentCore++;
        UpdateUI();
    }

    public bool IsAllCollected()
    {
        return currentCore >= totalCore;
    }

    void UpdateUI()
    {
        energyText.text = "Energy Core : " + currentCore + "/" + totalCore;
    }
}