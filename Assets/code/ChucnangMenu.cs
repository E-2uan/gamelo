using UnityEngine;
using UnityEngine.SceneManagement;

public class ChucnangMenu : MonoBehaviour
{
  public void moGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void thoat()
    {
        Application.Quit();
    }
}
