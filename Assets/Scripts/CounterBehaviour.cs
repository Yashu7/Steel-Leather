using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterBehaviour : MonoBehaviour
{
    public int currentTimeInSec;
    public int minStartingTimeInSec = 5;
    public int maxStartingTimeInSec = 100;
    public GameObject slot;
    public Image bar;
    

    public AudioClip outOfTimeSound;
    private AudioSource soundSource;

    public int penaltyForUnfinishedJob = 25;
    public bool canICount = true;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void CanIInvoke()
    {
        InvokeRepeating("OutputTime", 1, 1);
        canICount = false;
    }
    public void Restart() 
    {
        Debug.Log("Creating counter");
        currentTimeInSec = Random.Range(minStartingTimeInSec, maxStartingTimeInSec);

        gameObject.GetComponent<Text>().color = Color.white;
        gameObject.GetComponent<Text>().enabled = true;
       //Stops Invoke from stacking up 
        if (canICount)
        {
            CanIInvoke();
        }
        

    }

   
    void OutputTime() {
     if(currentTimeInSec <= 0) {
         //CancelInvoke();
         Debug.Log("Dropping job");
         Debug.Log("Removing gold");
         GameObject gg = GameObject.Find("GameGenerator");
           
            gg.GetComponent<PlayerInventory>().DeduceGold(penaltyForUnfinishedJob);
            slot.GetComponent<SlotBehaviour>().Fail();

        soundSource = GetComponent<AudioSource>();
        soundSource.PlayOneShot(outOfTimeSound, 0.7F);

         return;
     }


         currentTimeInSec = System.Convert.ToInt32(currentTimeInSec - ((Time.time + 1) - Time.time));
        
       


    }

    void FlashWarning()
    {
        if(currentTimeInSec < 1) {
            return;
        }
        if(currentTimeInSec < 10) 
     {
         Text textComponent = gameObject.GetComponent<Text>();
        textComponent.color = Color.red;
        textComponent.enabled = !textComponent.enabled;
     } 
    }

    // Update is called once per frame
    void Update()
    {
        Text textComponent = gameObject.GetComponent<Text>();
        textComponent.text = currentTimeInSec.ToString();
        
    }
}
