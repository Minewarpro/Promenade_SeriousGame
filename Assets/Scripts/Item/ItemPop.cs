using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemPop : MonoBehaviour
{

    [SerializeField] float hauteur;
    PlayerController player;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        gameObject.SetActive(false);

    }

    public void Pop()
    {
        Vector3 InitScale = transform.localScale;
        Vector3 playerPos = player.transform.position;
        player.canMove = false;

        transform.localScale = Vector3.zero;
        gameObject.SetActive(true);
        transform.DOScale(InitScale, 0.5f);
        transform.DOMoveY(transform.position.y + hauteur, 0.5f).OnComplete(() =>
        {
            transform.DOMove(playerPos, 0.5f).SetEase(Ease.InBack).OnComplete(() => player.canMove = true);

        });

    }

    void Update()
    {
        
    }
}
