using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StatueGame : MonoBehaviour
{
    PlayerController player;
    [SerializeField] GameObject BlackScreen;
    [SerializeField] GameObject CanvasUI;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    public void StartGame()
    {
        CanvasUI.SetActive(false);

        BlackScreen.GetComponent<CanvasGroup>().DOFade(1f, 1f).OnComplete(() =>
        {
            player.transform.position = new Vector3(70.76f, 0.94f, 60f);
            player.transform.rotation = new Quaternion(0, -0.382683426f, 0, 0.923879564f);
            BlackScreen.GetComponent<CanvasGroup>().DOFade(0f, 1f);
        });




    }




    void Update()
    {
        
    }
}
