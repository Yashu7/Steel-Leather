using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartBehaviour : MonoBehaviour
{
    public int LeatherCost;
    public int SteelCost;
    public int maxRange = 5;
    public int minRange = 1;
    [SerializeField]
    private bool isFixed;
    private SlotBehaviour parentSlot;

    

    // Start is called before the first frame update
    void Start()
    {
        LeatherCost = Random.Range(minRange, maxRange);
        SteelCost = Random.Range(minRange, maxRange);
    }

    public void SetParrentSlot(SlotBehaviour slot) {
        parentSlot = slot;
    }

    public void Fix() 
    {
        Debug.Log("Part fixed");
        isFixed = true;
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
    }

    public void Break() {
        isFixed = false;
    }

    public bool IsFixed() 
    {
        return isFixed;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isFixed) {
            
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        } else {
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        }
    }
    void OnMouseDown()
    {
        //todo refactor
        Debug.Log("Leather Cost:" + LeatherCost + " SteelCost: " + SteelCost);
        GameObject[] clickedParts = GameObject.FindGameObjectsWithTag("Clicked");
        foreach(GameObject clicked in clickedParts)
        {
            //removes clicked tag - unclicks them
            clicked.tag = "Job";
        }
        //set as currently being fixed
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

