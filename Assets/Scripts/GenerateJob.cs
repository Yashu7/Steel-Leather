using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateJob : MonoBehaviour
{
    public GameObject firstSlot;
    public GameObject secondSlot;
    public GameObject thirdSlot;

    public List<GameObject> createdJobs = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        GenerateNewJob(firstSlot.GetComponent<SlotBehaviour>());
        GenerateNewJob(secondSlot.GetComponent<SlotBehaviour>());
        GenerateNewJob(thirdSlot.GetComponent<SlotBehaviour>());
    }

    void GenerateNewJob(SlotBehaviour SlotBehaviour) 
    {
        SlotBehaviour.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        //todo implement
    }

}
