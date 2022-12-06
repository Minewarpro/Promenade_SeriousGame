using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core.Easing;
using DG.Tweening.Plugins.Options;



public class Engrenage : MonoBehaviour
{

    private bool isRecuperate = false;
    PlayerController player;
    EngrenageScore score;
    MontreScript montreScript;

    public static int EngrenageDate;
    [SerializeField] private int Date;

    private void OnTriggerEnter(Collider other)
    {
        isRecuperate = true;
        RecuperationEffect();
        score.GetEngrenage();
        EngrenageDate = Date;

        montreScript.Notif();

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

        transform.DOScale(transform.localScale * 0f, 0.5f).SetEase(Ease.InBack).SetEase(Ease.InBack).OnComplete(() => Destroy(gameObject));
    }

    public void DestroyCheck()
    {
        
        for (int i = 0; i < montreScript.DatesList.Count; i++)
        {
            if (Date == montreScript.DatesList[i])
            {
                Destroy(gameObject);
            }
        }
    }

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
        
        montreScript = FindObjectOfType<MontreScript>();
    }

    private void Start()
    {
        score = FindObjectOfType<EngrenageScore>();
    }

    private void Update()
    {
        if (isRecuperate)
        {
            Vector3 RefPos = new Vector3(player.transform.position.x, player.transform.position.y + 5, player.transform.position.z);
            transform.position = RefPos;
            transform.rotation = new Quaternion(0.19416073f, 0.461469531f, -0.00400541071f, 0.865639329f);
            transform.GetChild(1).Rotate(0, 0, 50 * Time.deltaTime);
            transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            transform.Rotate(new Vector3(0,50 * Time.deltaTime, 0));
        }
    }
}
