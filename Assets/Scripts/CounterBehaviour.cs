using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterBehaviour : MonoBehaviour
{
    public int currentTimeInSec;
    public int minStartingTimeInSec = 5;
    public int maxStartingTimeInSec = 15;
    public GameObject slot;

    public int penaltyForUnfinishedJob = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Restart() 
    {
        Debug.Log("Creating counter");
        currentTimeInSec = Random.Range(minStartingTimeInSec, maxStartingTimeInSec);

        InvokeRepeating("OutputTime", 1.0f, 1.0f);
    }

    void OutputTime() {
     if(currentTimeInSec < 1) {
         CancelInvoke();
         Debug.Log("Dropping job");
         slot.GetComponent<SlotBehaviour>().Clear();
         Debug.Log("Removing gold");
         GameObject gg = GameObject.Find("GameGenerator");
            gg.GetComponent<PlayerInventory>().DeduceGold(penaltyForUnfinishedJob);
         return;
     }
     currentTimeInSec--;
 }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Text>().text = currentTimeInSec.ToString(); 
    }
}
