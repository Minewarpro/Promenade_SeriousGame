using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class RondEffect : MonoBehaviour
{

    [SerializeField] float delay = 0;

    void Start()
    {
        StartCoroutine("Rond");
        transform.localScale = Vector3.zero;
    }

    private void Effect()
    {
        transform.localScale = Vector3.zero;
        Color color = new Color(1f, 1f, 1f, 1f);
        gameObject.GetComponent<Image>().color = color;
        transform.DOScale(4, 1.5f).SetEase(Ease.OutExpo);
        gameObject.GetComponent<Image>().DOFade(0, 1.5f).OnComplete(() => Effect());
    }


    IEnumerator Rond()
    {
        yield return new WaitForSeconds(delay);
        Effect();
    }





    void Update()
    {

    }
}
