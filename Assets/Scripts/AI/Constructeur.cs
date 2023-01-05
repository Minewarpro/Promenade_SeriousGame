using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Constructeur : MonoBehaviour
{
    [SerializeField] GameObject statue;
    [SerializeField] GameObject BlackScreen;

    public void PopStatue()
    {
        StartCoroutine(Wait());

        if (PlayerPrefs.GetString("1828Statue") == "Construite")
        {
            statue.SetActive(true);
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        BlackScreen.GetComponent<CanvasGroup>().DOFade(1, 0.4f).OnComplete(() =>
        {
            BlackScreen.GetComponent<CanvasGroup>().DOFade(0, 0.4f);
            statue.SetActive(true);
            PlayerPrefs.SetString("1828Statue", "Construite");
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
