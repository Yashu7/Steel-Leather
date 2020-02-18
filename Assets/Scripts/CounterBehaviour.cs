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
    public GameObject TimeBarPrefab;
    public GameObject TimeBar;



    public AudioClip outOfTimeSound;
    private AudioSource soundSource;

    public int penaltyForUnfinishedJob = 50;
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
        TimeBar = Instantiate(TimeBarPrefab, new Vector3(
            gameObject.transform.position.x,
            +0.3F,
            0
            )
            , Quaternion.identity);
        gameObject.GetComponent<Text>().color = Color.white;
        gameObject.GetComponent<Text>().enabled = true;
       //Stops Invoke from stacking up 
        if (canICount)
        {
            CanIInvoke();
        }
        

    }
    public void GetRidOfTimeBar()
    {
        Destroy(TimeBar);
    }
   
    void OutputTime() {
     if(currentTimeInSec <= 0) {
         //CancelInvoke();
         Debug.Log("Dropping job");
         Debug.Log("Removing gold");
         GameObject gg = GameObject.Find("GameGenerator");
            GetRidOfTimeBar();
           int score = GameObject.Find("MyScore").GetComponent<ScoreBehaviour>().GetScore();
           int penalty = penaltyForUnfinishedJob;
           if (score < 1000)
        {
            penalty = 50;
        }
        if (score > 1000 && score < 2000)
        {
            penalty = 75;
        }
        if (score > 2000)
        {
            penalty = 100;
        }

            gg.GetComponent<PlayerInventory>().DeduceGold(penalty);
            GameObject.Find("HowMuchGold").GetComponent<PopUpText>().popUpMessage("-", penalty);
            //Change label's color to red when failed.
            GameObject.Find("HowMuchGold").GetComponent<Text>().color = new Color32(255, 0, 0, 255);
            slot.GetComponent<SlotBehaviour>().Fail();

        soundSource = GetComponent<AudioSource>();
        soundSource.PlayOneShot(outOfTimeSound, 0.7F);

         return;
     }

        if (TimeBar.transform.localScale.x > -0.1F)
        {
            TimeBar.transform.localScale = new Vector3((currentTimeInSec * 0.1F) - 0.1F, TimeBar.transform.localScale.y, TimeBar.transform.localScale.z);
        }
        currentTimeInSec = System.Convert.ToInt32(currentTimeInSec - ((Time.time + 1) - Time.time));
        
       


    }
    //TODO : Is it even being used?
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
        if(slot.GetComponent<SlotBehaviour>().isFinished())
        {
            GetRidOfTimeBar();
        }
        
    }
}
