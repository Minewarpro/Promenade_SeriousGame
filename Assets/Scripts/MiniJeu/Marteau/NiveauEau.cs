using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NiveauEau : MonoBehaviour
{

    [SerializeField] Vector3 newPos;

    void Start()
    {
        if (PlayerPrefs.GetInt("MarteauWin") == 1)
        {
            transform.localPosition = newPos;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
