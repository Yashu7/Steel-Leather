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

    public AudioClip outOfTimeSound;
    private AudioSource soundSource;

    public int penaltyForUnfinishedJob = 25;
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
     if(currentTimeInSec <= 0) {
         CancelInvoke();
         Debug.Log("Dropping job");
         Debug.Log("Removing gold");
         GameObject gg = GameObject.Find("GameGenerator");
            Debug.Log("I lost muh money");
            gg.GetComponent<PlayerInventory>().DeduceGold(penaltyForUnfinishedJob);
            slot.GetComponent<SlotBehaviour>().Fail();

        soundSource = GetComponent<AudioSource>();
        soundSource.PlayOneShot(outOfTimeSound, 0.7F);

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
