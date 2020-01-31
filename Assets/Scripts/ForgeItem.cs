using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForgeItem : MonoBehaviour
{
    public Button forge;
    public GameObject actualJob;
    public GameObject gameGenerator;
    
    // Start is called before the first frame update
    void Start()
    {
        forge = gameObject.GetComponent<Button>();
        forge.onClick.AddListener(ButtonClicked);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ButtonClicked()
    {
        if (GameObject.FindWithTag("Clicked"))
        {
            actualJob = GameObject.FindWithTag("Clicked");
            gameGenerator = GameObject.FindWithTag("Player");
            gameGenerator.GetComponent<PlayerInventory>().DeduceLeatherCost(actualJob.GetComponent<PartBehaviour>().ReturnLeather());
            gameGenerator.GetComponent<PlayerInventory>().DeduceSteelCost(actualJob.GetComponent<PartBehaviour>().ReturnSteel());
            Destroy(actualJob);
        }

        




    }

}
