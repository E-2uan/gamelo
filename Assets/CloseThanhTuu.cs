using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private GameObject achievementPanel; 
    [SerializeField] private Button achievementButton;   
    [SerializeField] private Button closeButton;          

    void Start()
    {
        // Ẩn bảng thành tựu ban đầu
        achievementPanel.SetActive(false);

        // Gán sự kiện cho các nút
        achievementButton.onClick.AddListener(ShowAchievementPanel);
        closeButton.onClick.AddListener(CloseAchievementPanel);
    }

    void ShowAchievementPanel()
    {
        achievementPanel.SetActive(true); // Hiển thị bảng
    }

    void CloseAchievementPanel()
    {
        achievementPanel.SetActive(false); // Ẩn bảng
    }
}
