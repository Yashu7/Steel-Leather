using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PauseGame : MonoBehaviour
{
    
    public UnityEvent pauseEvent;
    // Start is called before the first frame update
    void Start()
    {
        if (pauseEvent == null)
            pauseEvent = new UnityEvent();

        pauseEvent.AddListener(TimeStop);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseEvent.Invoke();
        }
    }
    void TimeStop()
    {
        
            if(Time.timeScale == 1) 
        {
            Time.timeScale = 0;
        }
        else { 
            Time.timeScale = 1; 
        }
            
        
        
            
            
        
    }

}
