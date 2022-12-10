using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class QueteTuto : MonoBehaviour
{
    [SerializeField] GameObject QueteTutoContainer;

    PlayerController player;
    Quetes quetes;

    [SerializeField] CinemachineVirtualCamera virtualCamera;
    [SerializeField] GameObject quetePNJ;
    [SerializeField] GameObject QueteButton;
    [SerializeField] GameObject arrow;
    [SerializeField] GameObject blackScreen;
    [SerializeField] Sprite blackScreenTuto2;
    [SerializeField] GameObject colissionBox;
 
    private void OnTriggerEnter(Collider other)
    {
        player.canMove = false;
        Tuto();

    }

    private void Tuto()
    {
        virtualCamera.LookAt = quetePNJ.transform;
        QueteTutoContainer.SetActive(true);

        arrow.transform.DOLocalMove(new Vector3(191, 191, 0), 0.5f).SetEase(Ease.InCirc).SetLoops(-1, LoopType.Yoyo);
    }

    public void QueteTutoButton()
    {
        blackScreen.GetComponent<Image>().sprite = blackScreenTuto2;
        arrow.transform.localRotation = new Quaternion(1.49011594e-08f, 5.96046377e-08f, -0.94349438f, 0.331388652f);
        arrow.transform.DOLocalMove(new Vector3(-137, 267, 0), 0.001f).OnComplete(() =>
        arrow.transform.DOLocalMove(new Vector3(-228, 375, 0), 0.5f).SetEase(Ease.InCirc).SetLoops(-1, LoopType.Yoyo));
        quetes.QueteButtonTuto();

        QueteButton.SetActive(true);
    }

    public void QueteButton2()
    {
        QueteTutoContainer.SetActive(false);
        virtualCamera.LookAt = player.transform;
        player.canMove = true;
        colissionBox.SetActive(false);

    }

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        quetes = FindObjectOfType<Quetes>();
    }

    void Update()
    {
        
    }
}
