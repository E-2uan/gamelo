using UnityEngine;
using UnityEngine.SceneManagement;

public class ChucnangMenu : MonoBehaviour
{
  public void moGame()
    {
        SceneManager.LoadScene(1);
    }

    public void thoat()
    {
        Application.Quit();
    }
    public void backToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void playAgain()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
}
