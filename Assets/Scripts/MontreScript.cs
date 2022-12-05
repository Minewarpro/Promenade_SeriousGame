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
    [SerializeField] public List<int> DatesList = new List<int>();
    [SerializeField] Text DateText;
    [SerializeField] GameObject MontreScreen;

    private Quetes quetes;
    private Engrenage engrenage;

    private bool isOpen;
    private PlayerController playerController;
    private Transform NotifCanvas;

    private Vector3 initPosition;
    private Vector3 initScale;
    private Vector3 initNotifCanvasScale;
    private bool isNotifActive = false;

    public List<GameObject> RooulettesChiffres;


    public void OnClickButton()
    {
        if (!isOpen)
        {
            montre.transform.DOLocalRotate(new Vector3(0, 360, 0), 1f, RotateMode.LocalAxisAdd);
            montre.transform.DOScale(new Vector3(2.8f, 2.8f, 2.8f), 1f);
            montre.transform.DOLocalMove(new Vector3(-628, -440, -135), 1f).OnComplete(() => MontreScreen.SetActive(true));
            mAnimator.SetTrigger("Open");

            isOpen = true;
            playerController.canMove = false;
            joystick.transform.GetChild(0).GetComponent<Image>().raycastTarget = false;
            joystick.GetComponent<Image>().raycastTarget = false;

            if (isNotifActive)
            {
                transform.GetChild(4).DOKill();
                transform.GetChild(4).localScale = initNotifCanvasScale;
                NotifCanvas.gameObject.SetActive(false);
                isNotifActive = false;
            }
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
            if (DatesList[i].ToString() == DateText.text)
            {
                if (i+1 != DatesList.Count)
                {
                    DateText.text = DatesList[i+1].ToString();
                    int newDate = DatesList[i + 1];
                    ChangeTime(i, newDate);
                    return;
                }
                else
                {
                    DateText.text = DatesList[0].ToString();
                    int newDate = DatesList[0];
                    ChangeTime(i, newDate);
                    return;
                }
                
            }
        }
    }
    
    public void UpArrowButton()
    {
        for (int i=0; i<DatesList.Count; i++)
        {
            if (DatesList[i].ToString() == DateText.text)
            {
                if (i != 0)
                {
                    DateText.text = DatesList[i-1].ToString();
                    int newDate = DatesList[i - 1];
                    ChangeTime(i, newDate);
                    return;
                }
                else
                {
                    DateText.text = DatesList[DatesList.Count - 1].ToString();
                    int newDate = DatesList[DatesList.Count - 1];
                    ChangeTime(i, newDate);
                    return;
                }
                
            }
        }
    }

    private void ChangeTime(int i, int newDate)
    {
        string stringDate = newDate.ToString();

        for (i = 0; i<4; i++)
        {
            float NumberToGo = float.Parse(stringDate[i].ToString());

            RooulettesChiffres[i].transform.DOLocalRotate(new Vector3 (NumberToGo * 35, 0, 0), 1);
        }
    }



    public void TravelButton()
    {
        mAnimator.SetTrigger("TravelButton");

        
        if (SceneManager.GetActiveScene().name != DateText.text)
        {
            PlayerPrefs.SetString("CurrentDate", DateText.text);
            SceneManager.LoadScene(DateText.text);
        }
    }

    public void Notif()
    {
        DatesList.Add(Engrenage.EngrenageDate);
        DatesList.Sort();
        DatesList.Reverse();

        initNotifCanvasScale = transform.GetChild(4).localScale;
        isNotifActive = true;

        NotifCanvas.gameObject.SetActive(true);
        transform.GetChild(4).DOScale(NotifCanvas.transform.localScale * 1.01f, 0.3f)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.OutCirc);
    }

    public void StartAddDate()
    {
        if (PlayerPrefs.GetInt("Engrenage") >= 1 )
        {
            DatesList.Add(1603);
            DatesList.Sort();
            DatesList.Reverse();

            if (PlayerPrefs.GetInt("Engrenage") >= 2)
            {
                DatesList.Add(1783);
                DatesList.Sort();
                DatesList.Reverse();
            }
        }

        engrenage.DestroyCheck();
    }


    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            RooulettesChiffres.Add(transform.GetChild(4).GetChild(0).GetChild(1).GetChild(1).GetChild(i).GetChild(0).gameObject);
        }

        NotifCanvas = transform.GetChild(4).GetChild(1);

        quetes = FindObjectOfType<Quetes>();
        DateText.text = SceneManager.GetActiveScene().name;

        isOpen = false;
        mAnimator = montre.GetComponent<Animator>();
        playerController = FindObjectOfType<PlayerController>();
        engrenage = FindObjectOfType<Engrenage>();

        initPosition = montre.transform.localPosition;
        initScale = montre.transform.localScale;

        StartAddDate();

    }
  
    void Update()
    {
        
    }
}
