﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyMoreSteel : MonoBehaviour
{
    public GameObject gameGenerator;
    public Button buy;
    public int amount;
    // Start is called before the first frame update
    void Start()
    {
        gameGenerator = GameObject.FindWithTag("Player");
        buy = gameObject.GetComponent<Button>();
        buy.onClick.AddListener(ButtonClicked);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void ButtonClicked()
    {
       
        gameGenerator.GetComponent<PlayerInventory>().BuySteel(amount);
    
    }
}
