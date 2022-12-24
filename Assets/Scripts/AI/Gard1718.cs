using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Gard1718 : MonoBehaviour
{
 
    public void Move()
    {
        transform.Rotate(new Vector3(0, 135, 0));

        transform.DOMove(new Vector3(32.25f, 1f, 26f), 1f);
    }

}
