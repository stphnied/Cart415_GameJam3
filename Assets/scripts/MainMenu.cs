using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        Application.LoadLevel("testingnewdialogue");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void Menu(){
        SceneManager.LoadScene("MainScreen");
    }
    public void Quit() {
        Application.Quit();
    }
   
}
