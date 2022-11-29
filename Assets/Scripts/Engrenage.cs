using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Engrenage : MonoBehaviour
{
    private bool isRecuperate = false;
    PlayerController player;

    private void OnTriggerEnter(Collider other)
    {
        isRecuperate = true;
        Vector3 InitScale = transform.localScale;
        transform.localScale = transform.localScale * 0.3f;
        transform.DOScale(InitScale, 0.5f).SetEase(Ease.OutBack);

    }

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (isRecuperate)
        {
            Vector3 RefPos = new Vector3(player.transform.position.x, player.transform.position.y + 5, player.transform.position.z);
            transform.position = RefPos;
            transform.rotation = new Quaternion(0, 0.417155594f, 0, 0.908835113f);

        }
        else
        {
            transform.Rotate(new Vector3(0,50 * Time.deltaTime, 0));
        }
    }
}
