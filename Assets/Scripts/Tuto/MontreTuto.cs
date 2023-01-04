using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MontreTuto : MonoBehaviour
{
    [SerializeField] GameObject particles;
    [SerializeField] GameObject montre;
    PlayerController player;
    FirstPlay firstPlay;

    private bool isRecuperate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isRecuperate = true;

            particles.SetActive(false);
            RecuperationEffect();
        }
      
    }

    private void RecuperationEffect()
    {
        Vector3 InitScale = transform.localScale;
        transform.localScale = transform.localScale * 0.3f;
        transform.DOScale(InitScale, 0.5f).SetEase(Ease.OutBack);
        StartCoroutine(EngrenageDestroy(3));
    }

    private IEnumerator EngrenageDestroy(float sec)
    {
        yield return new WaitForSeconds(sec);

        transform.DOScale(transform.localScale * 0f, 0.5f).SetEase(Ease.InBack).SetEase(Ease.InBack).OnComplete(() => 
        {
            Destroy(gameObject);
            montre.SetActive(true);
            firstPlay.TutoMontre();
        });
    }


    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        firstPlay = FindObjectOfType<FirstPlay>();
    }

    void Update()
    {
        if (isRecuperate)
        {
            Vector3 RefPos = new Vector3(player.transform.position.x, player.transform.position.y + 5, player.transform.position.z);
            transform.position = RefPos;
            transform.rotation = new Quaternion(0.359767735f, 0.0447184779f, 0.0144819068f, 0.931857169f);
            transform.GetChild(4).Rotate(0, 0, 50 * Time.deltaTime);
            transform.GetChild(4).gameObject.SetActive(true);
        }
    }
}
