using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quetes : MonoBehaviour
{
    private int currentQueteNumber = 0;
    public List<GameObject> QuetesList;
    QueteButton queteButton;

    [SerializeField] private string newObjectif;

    PlayerController player;

    private void Awake()
    {
        queteButton = FindObjectOfType<QueteButton>();
    }

    void Start()
    {

        player = FindObjectOfType<PlayerController>();
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
    }

    void Update()
    {
        
    }
}
