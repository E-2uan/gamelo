using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChucnangMenu : MonoBehaviour
{
    //khai bao bien
    public Animator animatorNen,animatorTxt;

//BTN START
    //tao ham loadScene
    IEnumerator LoadScene()
    {
        //chon bien trigger dongScene
        animatorNen.SetTrigger("dong");
        animatorTxt.SetTrigger("dong");
        //time dongScene
        yield return new WaitForSeconds(1f);

        //chon bien trigger moScene
        animatorNen.SetTrigger("mo");
        animatorTxt.SetTrigger("mo");
        //time moScene
        yield return new WaitForSeconds(0.8f);

        //mo scene game
        SceneManager.LoadScene(1);
    }   
    //chuc nang Start
    public void moGame()
    {
        //lenh chay ham co the tam dung
        StartCoroutine(LoadScene());
    }

 
//BTN EXIT    
    //chuc nang EXIT
    public void thoat()
    {
        Application.Quit();
    }


//BTN BACK MENU
    //ham tam dung cho bnt back to menu
    IEnumerator BackMenuScene()
    {
        //chon bien trigger
        animatorNen.SetTrigger("dong");
        //lenh tam dung
        yield return new WaitForSeconds (1f);
        
        //chon bien trigger
        animatorNen.SetTrigger("mo");
        //lenh tam dung
        yield return new WaitForSeconds(0.8f);
        
        //load scene Menu
        SceneManager.LoadScene(0);
    }
    //chuc nang BackMenu
    public void backToMenu()
    {
        //goi ham tam dung
        StartCoroutine (BackMenuScene());
    }
    

//BTN PLAY AGAIN
    //tao ham tam dung cho play again
    IEnumerator PlayAgainScene()
    {
        //chon bien trigger
        animatorNen.SetTrigger("dong");
        animatorTxt.SetTrigger("dong");
        //time dong scene
        yield return new WaitForSeconds(1f);
        //goi bien trigger
        animatorNen.SetTrigger("mo");
        animatorTxt.SetTrigger("mo");
        //time mo scene
        yield return new WaitForSeconds(0.8f);
        //load lai scene gaem
        SceneManager .LoadScene(1);
        Time.timeScale = 1;
    } 
    //chuc nang playAgain
    public void playAgain()
    {   
        //lenh goi ham tam dung
        StartCoroutine (PlayAgainScene());
    }
}
