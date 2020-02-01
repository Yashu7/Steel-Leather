﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public int Leather;
    public int Steel;
    public bool ourStats;
    public GameObject leatherCount;
    public GameObject steelCount;
    public int Gold;
    // Start is called before the first frame update
    void Start()
    {
        if (!ourStats)
        {
            Leather = 10;
            Steel = 10;
            Gold = 100;
        }
    }

    // Update is called once per frame
    void Update()
    {

        leatherCount = GameObject.Find("MyLeather");
        leatherCount.GetComponent<Text>().text = Leather.ToString();

        steelCount = GameObject.Find("MySteel");
        steelCount.GetComponent<Text>().text = Steel.ToString();


    }
    //TO-DO: FINISH
    public int DeduceLeatherCost(int cost)
    {
        if(cost > Leather)
        {
            return 0;
        }
        return Leather = Leather - cost;
    }
    public int DeduceSteelCost(int cost)
    {
        if(cost > Steel)
        {
            return 0;
        }
        return Steel = Steel - cost;
    }
    public void AddGold(int prize)
    {
        Gold = Gold + prize;
    }
    public void DeduceGold(int prize)
    {
        Gold = Gold - prize;
    }
    public void BuyLeather()
    {

        Leather++;
    }
    public void BuySteel()
    {
        Steel++;
    }
    public int HowMuchGold()
    {
        return Gold;
    }
    public bool CanIForge(int LeatherCost,int SteelCost)
    {
        if(LeatherCost > Leather || SteelCost > Steel)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
