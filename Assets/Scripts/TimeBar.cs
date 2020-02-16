using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBar : MonoBehaviour
{
    public float startingPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.localScale.x > 0)
        {
            //gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x - 0.001F, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            //gameObject.transform.Translate(new Vector3(startingPos, 0F, 0F));
        }
        }
}
