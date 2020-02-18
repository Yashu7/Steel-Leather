using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    private Image a;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gm = GameObject.Find("MenuCloak");
        a = gm.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 0)
        {
            
            a.enabled = true;
        }
        if(Time.timeScale == 1)
        {
            a.enabled = false;
        }
    }
}
