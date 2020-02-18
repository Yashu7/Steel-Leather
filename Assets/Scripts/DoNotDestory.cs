using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestory : MonoBehaviour
{
    public bool isTutorial = false;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Tutorial()
    {
        isTutorial = true;
        Time.timeScale = 0;
    }
}
