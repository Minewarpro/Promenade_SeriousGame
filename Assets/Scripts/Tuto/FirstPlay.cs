using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FirstPlay : MonoBehaviour
{
    [SerializeField] GameObject montre;
    [SerializeField] GameObject montreTuto;

    [SerializeField] GameObject quete;
    [SerializeField] GameObject arrowTuto;
    [SerializeField] FixedJoystick joystick;
    [SerializeField] GameObject joystickContainer;
    [SerializeField] GameObject DaplacementContainer;
    [SerializeField] GameObject TutoContainer;

    [SerializeField] GameObject MontreTutoContainer;
    [SerializeField] GameObject arrowTutoMontre;

    PlayerController player;


    private bool isDaplacementContainerActive = true;


    void Start()
    {        
        TutoDeplacement();
        Initialization();

        player = FindObjectOfType<PlayerController>();

    }

    private void Initialization()
    {
        if (PlayerPrefs.GetInt("FirstPlay") == 1)
        {
            PlayerPrefs.SetString("Objectif", "Trouver la montre");

            montre.SetActive(false);
            quete.SetActive(false);            
        }
        else
        {
            DaplacementContainer.SetActive(false);
            montreTuto.SetActive(false);
            Destroy(TutoContainer);
            Destroy(gameObject);
        }
    }

    private void TutoDeplacement()
    {
        arrowTuto.transform.DOLocalMoveY(-156f, 0.5f).SetEase(Ease.InCirc).SetLoops(-1, LoopType.Yoyo);
    }

    public void TutoMontre()
    {
        MontreTutoContainer.SetActive(true);
        joystickContainer.SetActive(false);
        player.canMove = false;
        arrowTutoMontre.transform.DOLocalMove(new Vector3(154, 249, 0), 0.5f).SetEase(Ease.InCirc).SetLoops(-1, LoopType.Yoyo);
    }


    void Update()
    {
        if (joystick.Direction.magnitude > 0 && isDaplacementContainerActive)
        {
            DaplacementContainer.SetActive(false);
        }
    }
}
