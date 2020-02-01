using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartGame : MonoBehaviour
{
    public Button restart;
    // Start is called before the first frame update
    void Start()
    {
        restart = gameObject.GetComponent<Button>();
        restart.onClick.AddListener(ButtonClicked);

        
    }

    void ButtonClicked() 
    {
        Debug.Log("Restart game");
            SceneManager.LoadScene (sceneName:"SampleScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
