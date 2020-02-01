using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotBehaviour : MonoBehaviour
{
    private List<GameObject> parts = new List<GameObject>();
    public GameObject partPrefab;
    public GameObject counter; 
    public int partsCounter = 3;
    const float partOffset = 0.6f;
    private int toFix = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Repopulate() {
        Debug.Log("Repopulating slot");

        float parentX = gameObject.transform.position.x;
        float parentY = gameObject.transform.position.y + 1;
        
        AddPart(parentX, parentY, true);
        AddPart(parentX-partOffset, parentY-partOffset);
        AddPart(parentX+partOffset, parentY-partOffset, true);
        AddPart(parentX, parentY-(partOffset*2));
        AddPart(parentX-partOffset, parentY-(partOffset*3));
        AddPart(parentX+partOffset, parentY-(partOffset*3));


        counter.GetComponent<CounterBehaviour>().Restart();
    }

    void AddPart(float x, float y, bool isBroken= false) 
    {
            Debug.Log("Creating new part in slot");
            GameObject part = Instantiate(partPrefab, new Vector3(
                x, 
                y, 
                0
                )
                , Quaternion.identity);
            parts.Add(part);
            part.GetComponent<PartBehaviour>().SetParrentSlot(this);
            if(!isBroken) {
                part.GetComponent<PartBehaviour>().Fix();
            } else {
                part.GetComponent<PartBehaviour>().Break();
            }
    }

    public void Clear() {
        Debug.Log("Clearing parts");
        foreach(GameObject part in parts) {
            Destroy(part);
        }
        parts.Clear();
        Invoke("Repopulate", 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(parts.Count < 1) {
            return;
        }
        toFix = 0;
        foreach(GameObject part in parts) {
            if(!part.GetComponent<PartBehaviour>().IsFixed()) {
                toFix++;
            }
        }
        //Debug.Log("parts to fix:" + toFix.ToString());
        if(toFix < 1) {
            Debug.Log("Job done!");
           Clear();
        }
    }
}
