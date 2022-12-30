using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coloriage : MonoBehaviour
{
    void Start()
    {
        
    }

    public void Colorisation()
    {
        Debug.Log("color");
        gameObject.GetComponent<Image>().color = Color.red;
    }


    void Update()
    {
        
    }
}
