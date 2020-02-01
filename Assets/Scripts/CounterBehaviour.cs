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
    public Image bar;
    

    public AudioClip outOfTimeSound;
    private AudioSource soundSource;

    public int penaltyForUnfinishedJob = 25;
    


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    public void Restart() 
    {
        Debug.Log("Creating counter");
        currentTimeInSec = Random.Range(minStartingTimeInSec, maxStartingTimeInSec);

        gameObject.GetComponent<Text>().color = Color.white;
        gameObject.GetComponent<Text>().enabled = true;
        InvokeRepeating("OutputTime", 1, 1);
       // InvokeRepeating("FlashWarning", 1, 1);
       
    }
    public IEnumerator MyClock()
    {
        currentTimeInSec--;
        yield return new WaitForSeconds(1);
    }

    void OutputTime() {
     if(currentTimeInSec <= 0) {
         CancelInvoke();
         Debug.Log("Dropping job");
         Debug.Log("Removing gold");
         GameObject gg = GameObject.Find("GameGenerator");
           
            gg.GetComponent<PlayerInventory>().DeduceGold(penaltyForUnfinishedJob);
            slot.GetComponent<SlotBehaviour>().Fail();

        soundSource = GetComponent<AudioSource>();
        soundSource.PlayOneShot(outOfTimeSound, 0.7F);

         return;
     }

        StartCoroutine(MyClock());
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
