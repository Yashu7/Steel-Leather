using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public int s;
    public string highScoreString = "HighScore";
    public int highScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("MyScore"))
        {
            s = GameObject.Find("MyScore").GetComponent<ScoreBehaviour>().GetScore();
        }

       
        if(GameObject.Find("FinalScore"))
        {
            
            if (s > highScore)
            {
                PlayerPrefs.SetInt(highScoreString, s);
                PlayerPrefs.Save();
            }
            GameObject.Find("FinalScore").GetComponent<Text>().text = s.ToString();
            if (GameObject.Find("HighestScore"))
            {
                highScore = PlayerPrefs.GetInt(highScoreString, 0);
                GameObject.Find("HighestScore").GetComponent<Text>().text = highScore.ToString();
            }

        }
        
    }
}
