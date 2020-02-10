using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isAndroid : MonoBehaviour
{
    public bool isBuildAndroid;
    // Start is called before the first frame update
    void Start()
    {
        if (isBuildAndroid)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
