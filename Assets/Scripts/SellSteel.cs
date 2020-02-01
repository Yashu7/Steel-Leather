using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SellSteel : MonoBehaviour
{
    public GameObject gameGenerator;
    public Button sell;
    // Start is called before the first frame update
    void Start()
    {
        gameGenerator = GameObject.FindWithTag("Player");
        sell = gameObject.GetComponent<Button>();
        sell.onClick.AddListener(ButtonClicked);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void ButtonClicked()
    {

        gameGenerator.GetComponent<PlayerInventory>().SellSteel();

    }
}

