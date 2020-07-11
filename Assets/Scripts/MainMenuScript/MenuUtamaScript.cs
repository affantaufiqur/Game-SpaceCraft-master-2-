using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUtamaScript : MonoBehaviour
{
    public void play(){
        SceneManager.LoadScene("Level1");
    }

    public void faq()
    {
        SceneManager.LoadScene("HowToPlay");
    }
    public void quit(){
        Application.Quit();
    }
}
