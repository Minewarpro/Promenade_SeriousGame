using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColoriageManager : MonoBehaviour
{
    [SerializeField] List<Image> Images1622;
    [SerializeField] List<Image> Images1718;
    [SerializeField] List<Image> Images1765;
    [SerializeField] List<Image> Images1792;
    [SerializeField] List<Image> Images1828;

    [SerializeField] Color color1;
    [SerializeField] Color color2;
    [SerializeField] Color color3;
    [SerializeField] Color color4;
    [SerializeField] Color color5;

    [SerializeField] LayerMask layerColoriage;

    private int countGoodColor = 0;
    private bool needThrowRaycast = false;

    private void Check1622()
    {
        int countGoodAnswer = 0;

        foreach (Image images in Images1622)
        {
            if (images.color == color1)
            {
                countGoodAnswer += 1;
            }
            else
            {
                countGoodAnswer = 0;
            }
        }

        if (countGoodAnswer == Images1622.Count)
        {
            countGoodColor += 1;
        }else
        {
            countGoodColor = 0;
        }
    }

    private void Check1718()
    {
        int countGoodAnswer = 0;

        foreach (Image images in Images1718)
        {
            if (images.color == color2)
            {
                countGoodAnswer += 1;
            }
            else
            {
                countGoodAnswer = 0;
            }
        }

        if (countGoodAnswer == Images1718.Count)
        {
            countGoodColor += 1;
        }
        else
        {
            countGoodColor = 0;
        }
    }

    private void Check1765()
    {
        int countGoodAnswer = 0;

        foreach (Image images in Images1765)
        {
            if (images.color == color3)
            {
                countGoodAnswer += 1;
            }
            else
            {
                countGoodAnswer = 0;
            }
        }

        if (countGoodAnswer == Images1765.Count)
        {
            countGoodColor += 1;
        }
        else
        {
            countGoodColor = 0;
        }
    }

    private void Check1792()
    {
        int countGoodAnswer = 0;

        foreach (Image images in Images1792)
        {
            if (images.color == color4)
            {
                countGoodAnswer += 1;
            }
            else
            {
                countGoodAnswer = 0;
            }
        }

        if (countGoodAnswer == Images1792.Count)
        {
            countGoodColor += 1;
        }
        else
        {
            countGoodColor = 0;
        }
    }

    private void Check1828()
    {
        int countGoodAnswer = 0;

        foreach (Image images in Images1828)
        {
            if (images.color == color5)
            {
                countGoodAnswer += 1;
            }
            else
            {
                countGoodAnswer = 0;
            }
        }

        if (countGoodAnswer == Images1828.Count)
        {
            countGoodColor += 1;
        }
        else
        {
            countGoodColor = 0;
        }
    }

    private void CheckWin()
    {
        Check1622();
        Check1718();
        Check1765();
        Check1792();
        Check1828();

        if (countGoodColor == 5)
        {
            WinEffect();
        }else
        {
            countGoodColor = 0; 
        }
    }

    private void WinEffect()
    {
        Debug.Log("You Win !");

    }

    IEnumerator needThrowRay()
    {
        yield return new WaitForSeconds(0.1f);
        needThrowRaycast = false;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                StartCoroutine(needThrowRay());
                needThrowRaycast = true;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                if (needThrowRaycast)
                {
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);

                    if (Physics.Raycast(ray, out RaycastHit hit, 100, layerColoriage))
                    {
                        hit.collider.GetComponentInParent<Image>().color = ColorSelection.currentColor;
                        CheckWin();
                    }
                }
            }
        }
    }
}
