using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Quetes : MonoBehaviour
{
    private int currentQueteNumber = 0;
    public List<GameObject> QuetesList;
    QueteButton queteButton;
    QueteTuto queteTuto;

    [SerializeField] private string newObjectif;
    [SerializeField] private string newText;
    [SerializeField] private GameObject TextContainer;
    [SerializeField] private bool needTextApparition;
    [SerializeField] private GameObject joystickContainer;

    PlayerController player;

    private void Awake()
    {
        queteButton = FindObjectOfType<QueteButton>();
    }

    void Start()
    {

        player = FindObjectOfType<PlayerController>();
        queteTuto = FindObjectOfType<QueteTuto>();
        StartSceneQuete();
    }

    public void StartSceneQuete()
    {
        foreach (Quetes quete in Resources.FindObjectsOfTypeAll(typeof(Quetes)) as Quetes[])
        {
            QuetesList.Add(quete.gameObject);
        }

        currentQueteNumber = PlayerPrefs.GetInt("Quete", currentQueteNumber);
        SearchQuete();
    }

    public void SearchQuete()
    {
        Debug.Log(currentQueteNumber);
        for (int i = 0; i< QuetesList.Count; i++)
        {
            if (currentQueteNumber.ToString() == QuetesList[i].transform.GetChild(0).name)
            {
               QuetesList[i].transform.GetChild(0).gameObject.SetActive(true);
               return;
            }
        }
    }

    public void QueteButton()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance <= 5f)
        {
            PlayerPrefs.SetString("Objectif", newObjectif);
            queteButton.ChangeObjectif();
            currentQueteNumber = PlayerPrefs.GetInt("Quete") + 1;
            PlayerPrefs.SetInt("Quete", currentQueteNumber);
            SearchQuete();
            transform.GetChild(0).gameObject.SetActive(false);           
            TextApparition();
        }
    }

    public void TextApparition()
    {
        if (needTextApparition)
        {
            player.canMove = false;
            TextContainer.gameObject.SetActive(true);
            TextContainer.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = newText;
            joystickContainer.SetActive(false);
        }

        if (currentQueteNumber == 1)
        {
            queteTuto.OnTextApparition();
        }
    }

    public void TextClose()
    {
        player.canMove = true;
        TextContainer.gameObject.SetActive(false);
        joystickContainer.SetActive(true);

        if (currentQueteNumber == 1)
        {
            queteTuto.QueteTutoButton();
        }
    }


    public void QueteButtonTuto()
    {
        PlayerPrefs.SetString("Objectif", newObjectif);
        queteButton.ChangeObjectif();
        currentQueteNumber = PlayerPrefs.GetInt("Quete") + 1;
        PlayerPrefs.SetInt("Quete", currentQueteNumber);
        SearchQuete();
        transform.GetChild(0).gameObject.SetActive(false);
        TextApparition();
    }

    

    void Update()
    {
        
    }
}
