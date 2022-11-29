using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MontreScript : MonoBehaviour
{
    private Animator mAnimator;
    [SerializeField] GameObject montre;
    [SerializeField] GameObject joystick;
    [SerializeField] List<string> DatesList = new List<string>();
    [SerializeField] Text DateText;
    [SerializeField] GameObject MontreScreen;

    private Quetes quetes;

    private bool isOpen;
    private PlayerController playerController;

    private Vector3 initPosition;
    private Vector3 initScale;

    public void OnClickButton()
    {
        if (!isOpen)
        {
            montre.transform.DOLocalRotate(new Vector3(0, 360, 0), 1f, RotateMode.LocalAxisAdd);
            montre.transform.DOScale(new Vector3(3.3f, 3.3f, 3.3f), 1f);
            montre.transform.DOLocalMove(new Vector3(-595, -610, -135), 1f).OnComplete(() => MontreScreen.SetActive(true));
            mAnimator.SetTrigger("Open");

            isOpen = true;
            playerController.canMove = false;
            joystick.transform.GetChild(0).GetComponent<Image>().raycastTarget = false;
            joystick.GetComponent<Image>().raycastTarget = false;
        }
        
    }

    public void LeaveButton()
    {
        if (isOpen)
        {
            montre.transform.DOLocalRotate(new Vector3(0, -360, 0), 1f, RotateMode.LocalAxisAdd);
            montre.transform.DOScale(initScale, 1f);
            montre.transform.DOLocalMove(initPosition, 1f).OnComplete(() => isOpen = false);
            mAnimator.SetTrigger("Close");

            MontreScreen.SetActive(false);
            playerController.canMove = true;
            joystick.transform.GetChild(0).GetComponent<Image>().raycastTarget = true;
            joystick.GetComponent<Image>().raycastTarget = true;
        }
        
    }

    public void DownArrowButton()
    {
        for (int i=0; i<DatesList.Count; i++)
        {
            if (DatesList[i] == DateText.text)
            {
                if (i+1 != DatesList.Count)
                {
                    DateText.text = DatesList[i+1];
                    return;
                }
                else
                {
                    DateText.text = DatesList[0];
                    return;
                }
                
            }
        }
    }
    
    public void UpArrowButton()
    {
        for (int i=0; i<DatesList.Count; i++)
        {
            if (DatesList[i] == DateText.text)
            {
                if (i != 0)
                {
                    DateText.text = DatesList[i-1];
                    return;
                }
                else
                {
                    DateText.text = DatesList[DatesList.Count - 1];
                    return;
                }
                
            }
        }
    }

    public void TravelButton()
    {
        if (SceneManager.GetActiveScene().name != DateText.text)
        {
            PlayerPrefs.SetString("CurrentDate", DateText.text);
            SceneManager.LoadScene(DateText.text);
            //quetes.StartSceneQuete();
        }
    }

    void Start()
    {

        quetes = FindObjectOfType<Quetes>();
        DateText.text = SceneManager.GetActiveScene().name;

        isOpen = false;
        mAnimator = montre.GetComponent<Animator>();
        playerController = FindObjectOfType<PlayerController>();

        initPosition = montre.transform.localPosition;
        initScale = montre.transform.localScale;
    }
  
    void Update()
    {
        
    }
}
