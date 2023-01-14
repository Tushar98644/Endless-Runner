using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Load : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Menu;
    public Text highscoretext;

    private void Start()
    {
        highscoretext.text = "Highscore:" + ((int)PlayerPrefs.GetFloat("Highscore")).ToString();
    }

    public void Playgame()
    {
        SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
