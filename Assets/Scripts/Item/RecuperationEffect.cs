using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RecuperationEffect : MonoBehaviour
{

    private bool isRecuperate = false;
    PlayerController player;


    void Start()
    {
        player = FindObjectOfType<PlayerController>();  
    }

    private void OnTriggerEnter(Collider other)
    {
        isRecuperate = true;
        recuperationEffect();
    }

    private void recuperationEffect()
    {
        Vector3 InitScale = transform.localScale;
        transform.localScale = transform.localScale * 0.3f;
        transform.DOScale(InitScale, 0.5f).SetEase(Ease.OutBack);
        StartCoroutine(EngrenageDestroy(3));
    }

    private IEnumerator EngrenageDestroy(float sec)
    {
        yield return new WaitForSeconds(sec);

        transform.DOScale(transform.localScale * 0f, 0.5f).SetEase(Ease.InBack).SetEase(Ease.InBack).OnComplete(() => Destroy(gameObject));
    }


    void Update()
    {
        if (isRecuperate)
        {
            Vector3 RefPos = new Vector3(player.transform.position.x, player.transform.position.y + 5, player.transform.position.z);
            transform.position = RefPos;
            transform.rotation = new Quaternion(0.19416073f, 0.461469531f, -0.00400541071f, 0.865639329f);
        }
    }
}
