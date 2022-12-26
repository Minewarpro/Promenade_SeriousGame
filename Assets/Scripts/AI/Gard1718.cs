using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Gard1718 : MonoBehaviour
{
    private bool isOpen;


    public void Move()
    {
        transform.Rotate(new Vector3(0, 135, 0));

        transform.DOMove(new Vector3(32.25f, 1f, 26f), 1f);

        isOpen = true;
    }

    private void Start()
    {
        if (isOpen)
        {
            transform.position = new Vector3(32.25f, 1f, 26f);
        }
    }

}
