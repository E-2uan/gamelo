using TMPro;
using UnityEngine;

public class KillCounter : MonoBehaviour
{
    public TextMeshProUGUI killText;
    private int killCount = 0;

    public void AddKill()
    {
        killCount++;
        killText.text = "Kill: " + killCount.ToString();
    }
}
