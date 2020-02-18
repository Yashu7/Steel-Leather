using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestory : MonoBehaviour
{
<<<<<<< HEAD
    public bool isTutorial = false;
=======
>>>>>>> f2a494b18343f93e9f9d018efd9de57533aeffec
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
<<<<<<< HEAD
    public void Tutorial()
    {
        isTutorial = true;
        Time.timeScale = 0;
    }
=======
>>>>>>> f2a494b18343f93e9f9d018efd9de57533aeffec
}
