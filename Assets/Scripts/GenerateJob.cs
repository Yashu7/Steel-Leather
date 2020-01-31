using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateJob : MonoBehaviour
{
    public GameObject part;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(part, new Vector3(1 , 1, 0), Quaternion.identity);
        Instantiate(part, new Vector3(5, 1, 0), Quaternion.identity);
        Instantiate(part, new Vector3(-5, 1, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
