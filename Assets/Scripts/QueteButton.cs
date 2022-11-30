using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class QueteButton : MonoBehaviour
{

    private bool isOpen = false;
    
    void Start()
    {

        ChangeObjectif();
    }

    public void OnClickButton()
    {
        if (!isOpen)
        {
            transform.GetChild(0).GetComponent<RectTransform>().DOSizeDelta(new Vector2(693f, 129.3f), 0.5f);
            transform.GetChild(1).GetComponent<RectTransform>().DOSizeDelta(new Vector2(268.6f, 50f), 0.5f);
            isOpen = true;
        }else
        {
            transform.GetChild(0).GetComponent<RectTransform>().DOSizeDelta(new Vector2(114f, 129.3f), 0.5f);
            transform.GetChild(1).GetComponent<RectTransform>().DOSizeDelta(new Vector2(-269.8f, 50f), 0.5f);
            isOpen = false;
        }
    }

    public void ChangeObjectif()
    {
        transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetString("Objectif");
    }

    void Update()
    {
        
    }
}
