using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterBehaviour : MonoBehaviour
{
    public int currentTimeInSec;
    public int minStartingTimeInSec = 5;
    public int maxStartingTimeInSec = 15;
    public GameObject displayCounter;
    public GenerateJob job;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Creating counter");
        currentTimeInSec = Random.Range(minStartingTimeInSec, maxStartingTimeInSec);

        InvokeRepeating("OutputTime", 1.0f, 1.0f);
    }

    public void AttachJob(GenerateJob jobToAttach) {
        job = jobToAttach;
    }

    void OutputTime() {
     if(currentTimeInSec < 1) {
         CancelInvoke();
         Debug.Log("Dropping part");
         job.removePart();
         return;
     }
     currentTimeInSec--;
 }

    // Update is called once per frame
    void Update()
    {
        displayCounter = GameObject.Find("Counter1");
        displayCounter.GetComponent<Text>().text = currentTimeInSec.ToString();
    }
}
