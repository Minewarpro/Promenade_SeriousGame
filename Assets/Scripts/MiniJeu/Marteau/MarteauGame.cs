using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using FirstGearGames.SmoothCameraShaker;
using UnityEngine.SceneManagement;


public class MarteauGame : MonoBehaviour
{

    [SerializeField] GameObject arrows;
    [SerializeField] GameObject greenBar;
    [SerializeField] GameObject marteau;
    [SerializeField] GameObject bloc;
    [SerializeField] GameObject water;
    [SerializeField] GameObject BlackScreen;
    [SerializeField] public float arrowSpeed = 1;

    [SerializeField] ShakeData MyShakeWin;

    public static bool marteauIsWin;



    private bool canPlay = true;
    private int points = 0;

    private void Start()
    {
        ResetBar();
        ArrowMove();
        MarteauIdle();
    }

    private void ArrowMove()
    {
        arrows.transform.localPosition = new Vector3(-500, 0, 0);
        arrows.transform.DOLocalMoveX(500f, arrowSpeed).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
    }

    private void ResetBar()
    {
        greenBar.transform.localPosition = new Vector3(Random.Range(-168f,168f), 0, 0);
    }

    private void MarteauIdle()
    {
        marteau.transform.DOLocalRotate(new Vector3(0,0, 272f), 0.5f).SetLoops(-1, LoopType.Yoyo);
    }

    private void MarteauHitLoose()
    {
        marteau.transform.DOKill();
        marteau.transform.DOLocalRotate(new Vector3(0, 0, 180f), 0.8f).SetEase(Ease.OutBounce).OnComplete(
            () => {

                marteau.transform.DOLocalRotate(new Vector3(0, 0, 262f), 1f).OnComplete(() =>
                {

                    MarteauIdle();
                    ResetBar();
                    ArrowMove();
                    canPlay = true;

                });

            }
            );
    } 
        
    private void MarteauHitWin()
    {
        points += 1;

        marteau.transform.DOKill();
        marteau.transform.DOLocalRotate(new Vector3(0, 0, 180f), 0.8f).SetEase(Ease.InBack).OnComplete( 
            ()=> {
                marteau.transform.DOLocalRotate(new Vector3(0, 0, 262f), 1f).SetEase(Ease.OutBack).OnComplete(() =>
                {

                    MarteauIdle();
                    ResetBar();
                    greenBar.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(greenBar.transform.GetComponent<RectTransform>().sizeDelta.x - 100, 122);

                    ArrowMove();
                    marteau.transform.DOLocalMoveX(marteau.transform.position.x - 0.35f, 0.5f);
                    canPlay = true;

                });

                if (points < 3)
                {
                    bloc.transform.DOMoveX(bloc.transform.position.x - 0.35f, 0.5f).SetEase(Ease.OutQuart);
                    water.transform.DOMoveX(water.transform.position.x - 0.35f, 0.5f);

                }
                else
                {
                    bloc.transform.DOMoveX(bloc.transform.position.x - 2f, 0.5f).SetEase(Ease.OutQuart);


                    BlackScreen.GetComponent<CanvasGroup>().DOFade(1f, 0.5f).OnComplete(() =>
                    {
                        SceneManager.LoadScene("1765");
                        marteauIsWin = true;
                    });
                }

                CameraShakerHandler.Shake(MyShakeWin);

            }
            );
    }

    private void TouchScreen()
    {
        if (canPlay)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    arrows.transform.DOKill();
                    canPlay = false;

                    if (arrows.transform.localPosition.x >= (greenBar.transform.localPosition.x - (greenBar.transform.GetComponent<RectTransform>().sizeDelta.x / 2))
                         && arrows.transform.localPosition.x <= (greenBar.transform.localPosition.x + (greenBar.transform.GetComponent<RectTransform>().sizeDelta.x / 2)))
                    {
                        Debug.Log("BINGO");
                        MarteauHitWin();
                    }

                    else
                    {
                        Debug.Log("looser");
                        MarteauHitLoose();

                    }
                }
            }
        }
    }

    private void Update()
    {
        TouchScreen();
    }
}
