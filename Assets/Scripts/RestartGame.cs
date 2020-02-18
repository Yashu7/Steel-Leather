using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartGame : MonoBehaviour
{
    public bool isAndroid;
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
        Debug.Log("Restart game");
        if (!isAndroid)
        {
            SceneManager.LoadScene(sceneName: "SampleScene");
        }
        else
        {
            SceneManager.LoadScene(sceneName: "AndroidVersion");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
