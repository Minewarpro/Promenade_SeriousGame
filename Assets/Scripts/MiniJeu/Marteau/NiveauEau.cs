using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NiveauEau : MonoBehaviour
{

    void Start()
    {
        if (MarteauGame.marteauIsWin)
        {
            transform.localPosition = new Vector3(0.023f, -1.294f, 0.323f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
