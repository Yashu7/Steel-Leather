using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartBehaviour : MonoBehaviour
{
    public int LeatherCost;
    public int SteelCost;
    public int maxRange = 5;
    public int minRange = 1;
    public GameObject[] jobs;
    // Start is called before the first frame update
    void Start()
    {
        LeatherCost = Random.Range(minRange, maxRange);
        SteelCost = Random.Range(minRange, maxRange);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        Debug.Log("Leather Cost:" + LeatherCost + " SteelCost: " + SteelCost);
        jobs = GameObject.FindGameObjectsWithTag("Clicked");
        foreach(GameObject job in jobs)
        {
            job.tag = "Job";
        }
        gameObject.tag = "Clicked";
        
        


    }
    public int ReturnLeather()
    {
        return LeatherCost;
    }

    public int ReturnSteel()
    {
        return SteelCost;
    }
}

