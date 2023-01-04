using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Apparition : MonoBehaviour
{
    [SerializeField] GameObject DessinCanvas;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject BlackScreen;
    [SerializeField] GameObject clouds;

    public void AppartitionColoriage()
    {
        BlackScreen.GetComponent<CanvasGroup>().DOFade(1, 0.3f).OnComplete(()=>
        {
            DessinCanvas.SetActive(true);
            canvas.SetActive(false);
            clouds.SetActive(false);
            BlackScreen.GetComponent<CanvasGroup>().DOFade(0, 0.3f);
        });
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
