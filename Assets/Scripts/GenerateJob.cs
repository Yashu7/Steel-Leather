using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateJob : MonoBehaviour
{
    public GameObject part;
    public GameObject counter;

    private GameObject partInstance;
    private GameObject counterInstance;
    // Start is called before the first frame update
    void Start()
    {
        partInstance = Instantiate(part, new Vector3(1 , 1, 0), Quaternion.identity);
        counterInstance = Instantiate(counter, new Vector3(1,1,0), Quaternion.identity);
        counterInstance.GetComponent<CounterBehaviour>().AttachJob(this);
    }

    public void removePart() {
        Destroy(partInstance);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
