using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GetTutorial : MonoBehaviour
{
    public Button restart;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Started");
        restart = gameObject.GetComponent<Button>();
        restart.onClick.AddListener(ButtonClicked);
    }
    void ButtonClicked()
    {
        GameObject go = GameObject.Find("TutorialTrigger");
        go.GetComponent<DoNotDestory>().Tutorial();
            SceneManager.LoadScene(sceneName: "AndroidVersion");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
