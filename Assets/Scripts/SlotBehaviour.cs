using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotBehaviour : MonoBehaviour
{
    private List<GameObject> parts = new List<GameObject>();
    public List<Sprite> partSprite = new List<Sprite>();
    public List<Sprite> damagedPartSprite = new List<Sprite>();
    public GameObject partPrefab;
    public GameObject counter;
    public GameObject resultDisplay;
    public int partsCounter = 3;
    const float partOffset = 1f;
    private int toFix = 0;
    public Sprite s;

    public int GoldReward = 10;
    private bool broken;
    private bool finished;


    void Start()
    {
        
    }
    public bool RandomItem(bool broke)
    {
        broke = (Random.Range(0, 2) == 0);
        return broke;
    }
    public void Repopulate()
    {
        Debug.Log("Repopulating slot");

        float parentX = gameObject.transform.position.x;
        float parentY = gameObject.transform.position.y + 1;
        //Helmet
        AddPart(parentX, parentY + 0.1F, RandomItem(broken));
        //Left Hand
        AddPart(parentX - partOffset - 0.1F, parentY - partOffset, RandomItem(broken));
        //Right Hand
        AddPart(parentX + partOffset + 0.1F, parentY - partOffset, RandomItem(broken));
        //Breast Plate
        AddPart(parentX, parentY - (partOffset + 0.25F),RandomItem(broken));
        //Left Leg
        AddPart(parentX - partOffset + 0.5F, parentY - (partOffset * 2.4F), RandomItem(broken));
        //Right Leg
        AddPart(parentX + partOffset - 0.5F, parentY - (partOffset * 2.4F), RandomItem(broken));


        counter.GetComponent<CounterBehaviour>().Restart();
        resultDisplay.GetComponent<Text>().text = "";
        finished = false;
    }

    void AddPart(float x, float y, bool isBroken = false)
    {
        Debug.Log("Creating new part in slot");
        GameObject part = Instantiate(partPrefab, new Vector3(
            x,
            y,
            0
            )
            , Quaternion.identity);

        s = partSprite[parts.Count];

        part.GetComponent<SpriteRenderer>().sprite = s;
        parts.Add(part);

        part.GetComponent<PartBehaviour>().SetParrentSlot(this);
        if (!isBroken)
        {
            part.GetComponent<PartBehaviour>().Fix();
            part.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0.5F);
        }
        else
        {
            part.GetComponent<PartBehaviour>().Break();
        }
    }

    public void Success()
    {
        finished = true;
        Debug.Log("Succeess");
        resultDisplay.GetComponent<Text>().text = "Job Done!";
        GameObject.Find("GameGenerator").GetComponent<PlayerInventory>().AddGold(GoldReward);
        Invoke("Clear",0.5f);
    }

    public void Fail()
    {
        resultDisplay.GetComponent<Text>().text = "Fail!";
        Clear();
    }

    public void Clear()
    {
        Debug.Log("Clearing parts");
        
        foreach (GameObject part in parts)
        {
            Destroy(part);
        }
        parts.Clear();
        Invoke("Repopulate", 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (parts.Count < 1 || finished)
        {
            return;
        }
        toFix = 0;
        foreach (GameObject part in parts)
        {
            if (!part.GetComponent<PartBehaviour>().IsFixed())
            {
                toFix++;
            }
        }
        //Debug.Log("parts to fix:" + toFix.ToString());
        if (toFix < 1)
        {
            Debug.Log("Job done!");
            Success();
        }
    }
    
}
