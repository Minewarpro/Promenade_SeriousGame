using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoColoriage : MonoBehaviour
{
    [SerializeField] List<GameObject> blacks;

    private int i = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                blacks[i].SetActive(false);

                i += 1;

                if (i < blacks.Count)
                {
                    blacks[i].SetActive(true);
                }else
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
