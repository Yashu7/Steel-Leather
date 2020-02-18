using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class TutorialSteps : MonoBehaviour
{
    public List<string> tutorialTexts = new List<string>();
    public int steps = 0;
    // Start is called before the first frame update
    void Start()
    {
        tutorialTexts.Add("Welcome to the tutorial." + "\nTap >> ");
        tutorialTexts.Add("I'll explain your role in this game"
                    );
        tutorialTexts.Add("You are a blacksmith. You job is to repair armours of incoming heroes!");
        tutorialTexts.Add("Here are armour parts: Red are to be repaired.");
        tutorialTexts.Add("You pick part by tapping it");
        tutorialTexts.Add("Great! Picked part is now highlighted in colour yellow");
        tutorialTexts.Add("While highlighted, you can see part's repair cost down here");
        tutorialTexts.Add("First is cost, then there is how much resources you have left");
        tutorialTexts.Add("If you don't have enough leather or steel for repair, you can buy more by tapping one of BUY buttons");
        tutorialTexts.Add("One resource costs 50 Gold");
        //tutorialTexts.Add("You recieve gold for finishing repairing an armour on time");
        tutorialTexts.Add("Sometimes you can buy too much of one resource and forget about the second one, that's why you have option sell resource as well");
        tutorialTexts.Add("When you will have enough resources, press REPAIR button to repair the part");
        tutorialTexts.Add("If you finish repairing whole armour you will recieve more gold");
        tutorialTexts.Add("Remember that each armour has a timer on it, if you are too slow, you will lose gold and resources used on parts won't come back to you! Now, Let's Play"); 
        tutorialTexts.Add("");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.timeScale == 0)
        {
            if (steps >= 5)
            {
                steps++;
            }
            gameObject.GetComponent<Tutorial>().StartTutorial(tutorialTexts[steps]);
            if (steps < 4)
            {
                steps++;
            }
            if (steps == 3)
            {
                StartCoroutine(waitTutorial());
                gameObject.GetComponent<Tutorial>().MoveTutorial(new Vector3(0.5F, 0.5F, 0));
            }

            if (GameObject.FindWithTag("Clicked") && steps == 4)
            {
                steps = 5;
                gameObject.GetComponent<Tutorial>().StartTutorial(tutorialTexts[steps]);

            }
            if (steps == 6)
            {
                gameObject.GetComponent<Tutorial>().MoveTutorial(new Vector3(0, 1F, 0));
            }
            if (steps == 14)
            {
                Time.timeScale = 1;
                gameObject.GetComponent<Tutorial>().MoveTutorial(new Vector3(10, 10, 0));
            }
            if (steps == 13)
            {
                gameObject.GetComponent<Tutorial>().MoveTutorial(new Vector3(0, 1.5F, 0));
            }
            
        }

    }




        
    public IEnumerator waitTutorial()
    {
        Time.timeScale = 1;
        yield return new WaitForSeconds(1F);
        Time.timeScale = 0;
    }
}
