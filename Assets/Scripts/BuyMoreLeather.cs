using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyMoreLeather : MonoBehaviour
{
    public GameObject gameGenerator;
    public Button buy;
  
    public int amount;
    // Start is called before the first frame update
    void Start()
    {
        gameGenerator = GameObject.FindWithTag("Player");
        buy = gameObject.GetComponent<Button>();
        buy.onClick.AddListener(BuyButton);
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void BuyButton()
    {
        if (gameGenerator.GetComponent<PlayerInventory>().HowMuchGold() >= 10 * amount)
        {
            
            gameGenerator.GetComponent<PlayerInventory>().BuyLeather(amount);
        }
    }
    
}
