using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tweening : MonoBehaviour
{
    [SerializeField] float axeX;
    [SerializeField] float axeY;


    // Start is called before the first frame update
    void Start()
    {
        transform.DOLocalMove(new Vector3(axeX, axeY, 0), 0.5f).SetEase(Ease.InCirc).SetLoops(-1, LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
