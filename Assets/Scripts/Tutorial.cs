using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameObject tutorialBoard;
    public bool isTutorial = false;
    public GameObject firstBoard = null;
    public Transform textTutorial;
    public Transform canvasTutorial;
    // Start is called before the first frame update
    void Start()
    {
        StartTutorial("Tap to Begin");
    }
    public void startTutorial()
    {
        isTutorial = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartTutorial(string tutorialText)
    {
        if (Time.timeScale == 0 && isTutorial == true)
        {

            if (firstBoard == null)
            {

                firstBoard = Instantiate(tutorialBoard, gameObject.transform);
                canvasTutorial = firstBoard.transform.GetChild(0);
                textTutorial = canvasTutorial.GetChild(0);

                // firstBoard.transform.SetParent(gameObject.transform);

            }
            textTutorial.GetComponent<Text>().text = tutorialText;


        }
    }
    public void MoveTutorial(Vector3 v3)
    {
        firstBoard.transform.position = v3;
    }
}
