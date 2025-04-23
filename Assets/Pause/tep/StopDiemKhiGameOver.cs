using UnityEngine;

public class StopScoreOnGameOver : MonoBehaviour
{
    private bool daChay = false;

    void Update()
    {
        // Kiểm tra nếu GameOver Canvas đang bật và chỉ gọi 1 lần
        if (gameObject.activeInHierarchy && !daChay)
        {
            QuanLiDiem diemScript = FindObjectOfType<QuanLiDiem>();
            if (diemScript != null)
            {
                diemScript.GameOver();
                daChay = true;
            }
        }
    }
}