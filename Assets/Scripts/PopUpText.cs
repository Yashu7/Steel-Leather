﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpText : MonoBehaviour
{
    public Vector2 startPosition;
    
    public Color cr;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = gameObject.transform.position;
        cr = gameObject.GetComponent<Text>().color;
        
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void popUpMessage(string message1, int message2)
    {
        
        gameObject.GetComponent<Text>().text = message1 + message2.ToString();
        StartCoroutine(fadeOut());
        StartCoroutine(FadeOutRoutine());

    }
    private IEnumerator FadeOutRoutine()
    {
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Text>().text = "";
        gameObject.transform.position = startPosition;
    }
    private IEnumerator fadeOut()
    {
        for (float i = 0; i < 0.1F;)
        {
            gameObject.GetComponent<Text>().color -= new Color32(0, 0, 0, 23);
            gameObject.transform.position = gameObject.transform.position + new Vector3(0, i, 0);
            i = i + 0.01F;
            yield return null;
        }
    }
}
