using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quetes : MonoBehaviour
{

    //[SerializeField] List<GameObject> QuetesList;
    private int currentQueteNumber = 0;
    private Quetes quetesContainer;
    public List<GameObject> QuetesList;


    private void Awake()
    {
       // PlayerPrefs.SetInt("Quete", 0);
    }

    void Start()
    {
        foreach (Quetes quete in Resources.FindObjectsOfTypeAll(typeof(Quetes)) as Quetes[])
        {
            QuetesList.Add(quete.gameObject);
        }

        PlayerPrefs.SetInt("Quete", 0);

        currentQueteNumber = PlayerPrefs.GetInt("Quete", currentQueteNumber);
        SearchQuete();
    }

    private void SearchQuete()
    {
        Debug.Log("currentQueteNumber " + currentQueteNumber);
        Debug.Log("pref " + PlayerPrefs.GetInt("Quete"));
        for (int i = 0; i< QuetesList.Count; i++)
        {
            if (currentQueteNumber.ToString() == QuetesList[i].transform.GetChild(0).name)
            {
               QuetesList[i].transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }

    public void QueteButton()
    { 
        transform.GetChild(0).gameObject.SetActive(false);
        currentQueteNumber += 1;
        PlayerPrefs.SetInt("Quete", currentQueteNumber);

        SearchQuete();
    }

    void Update()
    {
        
    }
}
