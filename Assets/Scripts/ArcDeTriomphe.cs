using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class ArcDeTriomphe : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(0, - 20 * Time.deltaTime, 0);
    }
}
