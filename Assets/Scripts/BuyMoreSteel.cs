using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyMoreSteel : MonoBehaviour
{
    public GameObject gameGenerator;
    public Button buy;
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
        if (gameGenerator.GetComponent<PlayerInventory>().HowMuchGold() >= 10)
        {
            gameGenerator.GetComponent<PlayerInventory>().DeduceGold(10);
            gameGenerator.GetComponent<PlayerInventory>().BuySteel();
        }
    }
}

