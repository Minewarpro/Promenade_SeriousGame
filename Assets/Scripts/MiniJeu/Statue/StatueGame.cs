using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;
using UnityEngine.UI;

public class StatueGame : MonoBehaviour
{
    PlayerController player;
    [SerializeField] GameObject BlackScreen;
    [SerializeField] GameObject CanvasUI;
    [SerializeField] CinemachineVirtualCamera virtualCamera1;
    [SerializeField] CinemachineVirtualCamera virtualCamera2;
    [SerializeField] GameObject TutoStatue;
    [SerializeField] GameObject Bar;
    [SerializeField] GameObject GameCanvas;
    [SerializeField] GameObject Statue;
    [SerializeField] Camera mainCamera;
    [SerializeField] Animator mAnimator;


    private bool tutoActive = false;
    private bool isPlaying = false;

    float fillBar;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        fillBar = Bar.GetComponent<Image>().fillAmount;
        mainCamera.GetComponent<CinemachineBrain>().m_DefaultBlend.m_Time = 0;
    }

    public void StartGame()
    {
        CanvasUI.SetActive(false);

        BlackScreen.GetComponent<CanvasGroup>().DOFade(1f, 0.5f).OnComplete(() =>
        {
            PlayerController.canRotate = false;
            player.transform.position = new Vector3(70.76f, 0.94f, 60f);
            player.transform.rotation = Quaternion.Euler(0, -45f, 0);
            virtualCamera1.Priority = 0;
            virtualCamera2.Priority = 10;
            TutoStatue.SetActive(true);
            GameCanvas.SetActive(true);

            StartCoroutine(WaitFor());

        });
    }

    private IEnumerator WaitFor()
    {
        yield return new WaitForSeconds(0.5f);
        
        BlackScreen.GetComponent<CanvasGroup>().DOFade(0f, 0.5f).OnComplete(() => tutoActive = true);
    }
    
    private void Win()
    {
        Statue.transform.DORotate(new Vector3(0,45,-96), 3f).SetEase(Ease.InQuint).OnComplete(()=> CanvasUI.SetActive(true));
        mainCamera.GetComponent<CinemachineBrain>().m_DefaultBlend.m_Time = 1;
        virtualCamera1.Priority = 10;
        virtualCamera2.Priority = 0;

        GameCanvas.SetActive(false);
        player.transform.rotation = Quaternion.Euler(0, -135f, 0);
        player.transform.DOMove(new Vector3(67.5f, 0.991936147f, 56.7299995f), 1f).OnComplete(()=> {
            mAnimator.SetTrigger("Idle");
            PlayerController.canRotate = true;
        });
        mAnimator.SetTrigger("Run");
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if (tutoActive)
                {
                    Destroy(TutoStatue);
                    isPlaying = true;
                    tutoActive = false;
                    Bar.GetComponent<Image>().fillAmount += 0.1f;
                }
                if (isPlaying)
                {
                    Bar.GetComponent<Image>().fillAmount += 0.1f;
                }
            }
        }

        if (isPlaying)
        {
            Bar.GetComponent<Image>().fillAmount -= 0.3f * Time.deltaTime;
        }
        
        if (Bar.GetComponent<Image>().fillAmount >= 0.95f && isPlaying)
        {
            isPlaying = false;
            Bar.GetComponent<Image>().fillAmount = 1;
            Win();
        }
    }
}
