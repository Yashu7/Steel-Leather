using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestory : MonoBehaviour
{

    public bool isStartTutorial = false;
    public GameObject tutorialStarter;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (isStartTutorial)
        {
            if (tutorialStarter == null)
            {
                tutorialStarter = GameObject.FindWithTag("Tutorial");
                tutorialStarter.GetComponent<Tutorial>().startTutorial();
                Time.timeScale = 0;
                isStartTutorial = false;
            }
        }
    }

    public void Tutorial()
    {
        isStartTutorial = true;
        
    }

}
