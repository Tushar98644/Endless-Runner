using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    //public GameObject selectcharacter;
    public GameObject Deathmenu;
    

    //public void OnSelectCharacter()
    //{
    //    selectcharacter.SetActive(true);
    //    Mainmenu.SetActive(false);

    //}

    private void Start()
    {
       
    }



    public void OnPlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void OnMenupress()
    {
        SceneManager.LoadScene("MainMenu");

    }


    public void OnQutigame()
    {
        Debug.Log("Quiting game....");
        Application.Quit();
    }
}