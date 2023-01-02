using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrowRaycast : MonoBehaviour
{

    [SerializeField] LayerMask layerColoriage;
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

                if (Physics.Raycast(ray, out RaycastHit hit, 100, layerColoriage))
                {
                    hit.collider.GetComponentInParent<Image>().color = ColorSelection.currentColor;
                }
            }
        }
    }
}
