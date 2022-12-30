using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowRaycast : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);

                if (Physics.Raycast(ray, out RaycastHit hit, 100))
                {
                    Debug.Log(hit.transform.name);
                    Debug.Log("hit");
                }
            }
        }
    }
}
