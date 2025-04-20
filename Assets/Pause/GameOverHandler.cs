using UnityEngine;

public class GameOverHandler : MonoBehaviour
{
    private bool hasIncremented = false; // Tránh tăng DeathCount nhiều lần

    void Update()
    {
        // Kiểm tra nếu GameOver được bật
        if (gameObject.activeSelf && !hasIncremented)
        {
            hasIncremented = true;
            IncrementDeathCount();
        }
    }

    private void IncrementDeathCount()
    {
        // Lấy DeathCount từ PlayerPrefs, mặc định là 0 nếu chưa có
        int deathCount = PlayerPrefs.GetInt("DeathCount", 0);
        deathCount++; // Tăng DeathCount
        PlayerPrefs.SetInt("DeathCount", deathCount); // Lưu lại vào PlayerPrefs
        PlayerPrefs.Save();
        Debug.Log("DeathCount incremented to: " + deathCount);
    }

    // Reset trạng thái khi GameOver bị tắt (để lần sau có thể tăng lại)
    void OnDisable()
    {
        hasIncremented = false;
    }
}

