using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuanLiDiem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI diemText;
    private float diem = 0;
    private bool isGameOver = false;

    void Update()
    {
        if (!isGameOver)
        {
            UpdateScore();
        }
    }

    private void UpdateScore()
    {
        diem += Time.deltaTime * 10;
        diemText.text = "Score: " + Mathf.FloorToInt(diem).ToString();
    }

    public void GameOver()
    {
        isGameOver = true;
    }
}