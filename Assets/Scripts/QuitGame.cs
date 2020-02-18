using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitGame : MonoBehaviour
{
    public Button quit;
    // Start is called before the first frame update
    void Start()
    {
        quit = gameObject.GetComponent<Button>();
        quit.onClick.AddListener(ButtonClicked);
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKey(KeyCode.Escape))
             {
                 Debug.Log("Esc pressed");
                 Application.Quit();
             }
    }

    void ButtonClicked() 
    {
       Application.Quit();
    }
}
