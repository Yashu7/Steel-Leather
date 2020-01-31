using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowMuchSteel : MonoBehaviour
{
    public GameObject steelCost;
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
            steelCost = GameObject.FindWithTag("Clicked");
            amount = steelCost.GetComponent<PartBehaviour>().ReturnSteel().ToString();
            gameObject.GetComponent<Text>().text = amount;
        }
    }
}
