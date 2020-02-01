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
    public GameObject job;

    public int penaltyForUnfinishedJob = 100;

    private int jobIndex;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Creating counter");
        currentTimeInSec = Random.Range(minStartingTimeInSec, maxStartingTimeInSec);

        InvokeRepeating("OutputTime", 1.0f, 1.0f);
    }

    public void AttachJob(GameObject jobToAttach) {
        job = jobToAttach;
    }

    public void SetIndex(int index) {
            jobIndex = index;
    }

    void OutputTime() {
     if(currentTimeInSec < 1) {
         CancelInvoke();
         Debug.Log("Dropping part");
         Destroy(job);
         Debug.Log("Removing gold");
         GameObject gg = GameObject.Find("GameGenerator");
         gg.GetComponent<PlayerInventory>().DeduceGold(penaltyForUnfinishedJob);
         Destroy(gameObject);
         return;
     }
     currentTimeInSec--;
 }

    // Update is called once per frame
    void Update()
    {
        if(jobIndex > 0) {
           displayCounter = GameObject.Find("Counter" + jobIndex);
        displayCounter.GetComponent<Text>().text = currentTimeInSec.ToString(); 
        }
        
    }
}
