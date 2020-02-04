using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void popUpMessage(string message1, int message2)
    {
        gameObject.GetComponent<Text>().text = message1 + message2.ToString();
        StartCoroutine(FadeOutRoutine());

    }
    private IEnumerator FadeOutRoutine()
    {
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Text>().text = "";
    }
}
