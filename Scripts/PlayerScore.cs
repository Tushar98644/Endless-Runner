using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    [Header("score")]
    private float score = 0f;
    public Text ScoreText;
    private int difficultylevel = 1;
    private int maxdifflvl = 10;
    private int scoretonextlvl=10;
   

    [Header("Death score")]
    private bool isdead = false;
    public Text deathscore;


    void Update()
    {
        if (isdead)
            return;

        if(score>=scoretonextlvl)
        {
            Levelup();
        }

        score += Time.deltaTime * difficultylevel;
        ScoreText.text=((int)score).ToString();

    }

    void Levelup()
    {
        if (difficultylevel == maxdifflvl)
            return;

        scoretonextlvl *= 2;
        difficultylevel ++;

        GetComponent<Player>().Speedincrement(difficultylevel);
    }

    public void OnDeath()
    {
        isdead = true;
        if(PlayerPrefs.GetFloat("Highscore")<score)
          PlayerPrefs.SetFloat("Highscore", score);


        deathscore.text = ((int)score).ToString();
    }
}
