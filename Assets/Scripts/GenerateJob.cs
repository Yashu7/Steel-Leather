using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateJob : MonoBehaviour
{
    public GameObject part;
    public GameObject firstJob;
    public GameObject secondJob;
    public GameObject thirdJob;

    public List<GameObject> createdJobs = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {


        thirdJob = Instantiate(part, new Vector3(5, 1, 0), Quaternion.identity);
        secondJob = Instantiate(part, new Vector3(1, 1, 0), Quaternion.identity);
        firstJob = Instantiate(part, new Vector3(-5, 1, 0), Quaternion.identity);
        

    }

    // Update is called once per frame
    void Update()
    {
        if (secondJob == null)
        {
            secondJob = Instantiate(part, new Vector3(1, 1, 0), Quaternion.identity);
           
        }
        if (firstJob == null)
        {
            firstJob = Instantiate(part, new Vector3(-5, 1, 0), Quaternion.identity);

        }
        if (thirdJob == null)
        {
            thirdJob = Instantiate(part, new Vector3(5, 1, 0), Quaternion.identity);

        }
    }
}
