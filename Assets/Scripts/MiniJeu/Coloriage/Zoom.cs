using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class Zoom : MonoBehaviour
{

    [SerializeField] GameObject dessin;

    [SerializeField] GameObject plus;
    [SerializeField] GameObject moins;

    [SerializeField] float maxRangeX = 10;
    [SerializeField] float maxRangeY = 200;

    private float minRangeY = 0;

    [SerializeField] float moveSpeed = 1f;

    [SerializeField] float deltaPosition = 1f;

    private bool isZooming = false;
    private int zoom = 0;
    public static Vector3 initPosDessin;
    public static Vector3 initScale;

    public void ZoomPlus()
    {
        Vector3 scaleDessin = new Vector3(dessin.transform.localScale.x + 0.5f, dessin.transform.localScale.y + 0.5f, dessin.transform.localScale.z + 0.5f);

        if (!isZooming && zoom <3)
        {
            dessin.transform.DOScale(scaleDessin, 0.2f).OnComplete(() => isZooming = false);
            dessin.GetComponent<RectTransform>().DOLocalMove(initPosDessin, 0.2f);
            isZooming = true;
            zoom += 1;
        }

        if (zoom == 3)
        {
            plus.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        }
            moins.GetComponent<Image>().color = new Color(1, 1, 1, 1);
    }

    public void ZoomMoins()
    {
        Vector3 scaleDessin = new Vector3(dessin.transform.localScale.x - 0.5f, dessin.transform.localScale.y - 0.5f, dessin.transform.localScale.z - 0.5f);

        if (!isZooming && zoom > 0)
        {
            dessin.transform.DOScale(scaleDessin, 0.2f).OnComplete(() => isZooming = false);
            dessin.GetComponent<RectTransform>().DOLocalMove(initPosDessin, 0.2f);
            isZooming = true;
            zoom -= 1;
        }

        if (zoom == 0)
        {
            moins.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        }
            plus.GetComponent<Image>().color = new Color(1, 1, 1, 1);
    }

    private void Start()
    {
        initPosDessin = dessin.GetComponent<RectTransform>().localPosition;
        initScale = dessin.GetComponent<RectTransform>().localScale;
        minRangeY = - maxRangeY;
    }


    private void Update()
    {
        if (Input.touchCount > 0 && zoom >0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                if (touch.deltaPosition.x > deltaPosition || touch.deltaPosition.x < -deltaPosition || touch.deltaPosition.y > deltaPosition || touch.deltaPosition.y < -deltaPosition)
                dessin.GetComponent<RectTransform>().localPosition = new Vector3(
                    dessin.GetComponent<RectTransform>().localPosition.x + touch.deltaPosition.x * moveSpeed,
                    dessin.GetComponent<RectTransform>().localPosition.y + touch.deltaPosition.y * moveSpeed, 
                    0);
            }
        }

        if (dessin.GetComponent<RectTransform>().localPosition.x >= maxRangeX)
        {
            dessin.GetComponent<RectTransform>().localPosition = new Vector2( maxRangeX, dessin.GetComponent<RectTransform>().localPosition.y);
        }

        if (dessin.GetComponent<RectTransform>().localPosition.x <= -maxRangeX)
        {
            dessin.GetComponent<RectTransform>().localPosition = new Vector2(-maxRangeX, dessin.GetComponent<RectTransform>().localPosition.y);
        }

        if (dessin.GetComponent<RectTransform>().localPosition.y >= maxRangeY)
        {
            dessin.GetComponent<RectTransform>().localPosition = new Vector2(dessin.GetComponent<RectTransform>().localPosition.x, maxRangeY);
        }

        if (dessin.GetComponent<RectTransform>().localPosition.y <= minRangeY)
        {
            dessin.GetComponent<RectTransform>().localPosition = new Vector2(dessin.GetComponent<RectTransform>().localPosition.x, minRangeY);
        }
    }
}
