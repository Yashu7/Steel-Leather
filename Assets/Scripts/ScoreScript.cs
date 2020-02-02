using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public int s;
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
            GameObject.Find("FinalScore").GetComponent<Text>().text = s.ToString();
        }
    }
}
