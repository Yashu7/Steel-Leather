using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartBehaviour : MonoBehaviour
{
    public int LeatherCost;
    public int SteelCost;
    public int maxRange = 1;
    public int minRange = 2;
    [SerializeField]
    public bool isFixed;
    private SlotBehaviour parentSlot;
    
    public int score;
    

    
    public void difficultyLevel()
    {
       score = GameObject.Find("MyScore").GetComponent<ScoreBehaviour>().GetScore();
        if (score < 1000)
        {
            maxRange = 3;
            minRange = 1;
        }
        if (score > 1000 && score < 2000)
        {
            maxRange = 5;
            minRange = 2;
        }
        if (score > 2000)
        {
            maxRange = 7;
            minRange = 4;
        }
       
        
    }
    // Start is called before the first frame update
    void Start()
    {
        difficultyLevel();  
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
        //gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);

        //gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0.5F);
    }

    public void Break() {
        isFixed = false;
    }

    public void Good()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0.5F);
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
        } 
        else
        {
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        }
        
        if (gameObject.tag == "Clicked")
        {
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
        }
        difficultyLevel();
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
        if (!isFixed)
        {

            gameObject.tag = "Clicked";

           
        }
        StartCoroutine(ClickElement());

    }
    IEnumerator ClickElement()
    {
        gameObject.transform.localScale = new Vector3(0.85F, 0.85F, 1);
        yield return new WaitForSeconds(0.35F);
        gameObject.transform.localScale = new Vector3(1, 1, 1);
        

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

