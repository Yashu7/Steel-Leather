using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowMuchLeather : MonoBehaviour
{
    public GameObject leatherCost;
    public string amount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("Clicked"))
        {
            leatherCost = GameObject.FindWithTag("Clicked");
            amount = leatherCost.GetComponent<PartBehaviour>().ReturnLeather().ToString();
            gameObject.GetComponent<Text>().text = amount;
        }
        else
        {
            gameObject.GetComponent<Text>().text = "0";
        }
    }
    }

