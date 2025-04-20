using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SuKienThanhTuu : MonoBehaviour
{
    [SerializeField] private GameObject achievementPanel;
    [SerializeField] private Button achievementButton;
    [SerializeField] private Button closeButton;
    [SerializeField] private TextMeshProUGUI textValuePlay;
    [SerializeField] private TextMeshProUGUI textValueDeath;

    private int playCount = 0;
    private int deathCount = 0;

    void Start()
    {
        // Load dữ liệu từ PlayerPrefs
        playCount = PlayerPrefs.GetInt("PlayCount", 0);
        deathCount = PlayerPrefs.GetInt("DeathCount", 0); // Đọc DeathCount từ PlayerPrefs

        if (achievementPanel != null)
        {
            achievementPanel.SetActive(false);
        }
        else
        {
            Debug.LogError("Achievement Panel is not assigned!");
        }

        if (achievementButton != null)
        {
            achievementButton.onClick.AddListener(ShowAchievementPanel);
        }
        else
        {
            Debug.LogError("Achievement Button is not assigned!");
        }

        if (closeButton != null)
        {
            closeButton.onClick.AddListener(CloseAchievementPanel);
        }
        else
        {
            Debug.LogError("Close Button is not assigned!");
        }

        UpdatePlayCountUI();
        UpdateDeathCountUI();
    }

    public void ShowAchievementPanel()
    {
        if (achievementPanel != null)
        {
            achievementPanel.SetActive(true);
            // Cập nhật lại DeathCount khi mở panel (đề phòng giá trị thay đổi)
            deathCount = PlayerPrefs.GetInt("DeathCount", 0);
            UpdateDeathCountUI();
        }
        else
        {
            Debug.LogError("Achievement Panel is null!");
        }
    }

    public void CloseAchievementPanel()
    {
        if (achievementPanel != null)
        {
            achievementPanel.SetActive(false);
        }
    }

    public void IncrementPlayCount()
    {
        playCount++;
        PlayerPrefs.SetInt("PlayCount", playCount);
        PlayerPrefs.Save();
        UpdatePlayCountUI();
    }

    public void IncrementDeathCount()
    {
        deathCount++;
        PlayerPrefs.SetInt("DeathCount", deathCount);
        PlayerPrefs.Save();
        UpdateDeathCountUI();
    }

    private void UpdatePlayCountUI()
    {
        if (textValuePlay != null)
        {
            textValuePlay.text = playCount.ToString("D6");
        }
        else
        {
            Debug.LogError("TextValuePlay is not assigned!");
        }
    }

    private void UpdateDeathCountUI()
    {
        if (textValueDeath != null)
        {
            textValueDeath.text = deathCount.ToString("D6");
        }
        else
        {
            Debug.LogError("TextValueDeath is not assigned!");
        }
    }
}