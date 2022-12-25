using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using FirstGearGames.SmoothCameraShaker;

public class MarteauGame : MonoBehaviour
{

    [SerializeField] GameObject arrows;
    [SerializeField] GameObject greenBar;
    [SerializeField] GameObject marteau;
    [SerializeField] GameObject bloc;
    [SerializeField] GameObject water;
    [SerializeField] public float arrowSpeed = 1;

    [SerializeField] ShakeData MyShake;


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
        arrows.transform.localPosition = new Vector3(-600, 0, 0);
        arrows.transform.DOLocalMoveX(600f, arrowSpeed).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
    }

    private void ResetBar()
    {
        greenBar.transform.localPosition = new Vector3(Random.Range(-368f,368f), 0, 0);
        greenBar.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(Random.Range(260, 468), 122);
    }

    private void MarteauIdle()
    {
        marteau.transform.DOLocalRotate(new Vector3(0,0, 272f), 0.5f).SetLoops(-1, LoopType.Yoyo);
    }

    private void MarteauHitLoose()
    {
        marteau.transform.DOKill();
        marteau.transform.DOLocalRotate(new Vector3(0, 0, 180f), 0.8f).SetEase(Ease.OutBounce).OnComplete( 
            ()=>         
            marteau.transform.DOLocalRotate(new Vector3(0, 0, 262f), 1f).OnComplete(()=> { 
                
                MarteauIdle(); 
                ResetBar();
                ArrowMove();
                canPlay = true;

            })
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
                }

                CameraShakerHandler.Shake(MyShake);

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
