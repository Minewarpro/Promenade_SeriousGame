using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quetes : MonoBehaviour
{

    //[SerializeField] List<GameObject> QuetesList;
    private int currentQueteNumber = 0;
    public List<GameObject> QuetesList;


    private void Awake()
    {
       // PlayerPrefs.SetInt("Quete", 0);
    }

    void Start()
    {
        //PlayerPrefs.SetInt("Quete", 0);

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

        Debug.Log("search");
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
        currentQueteNumber = PlayerPrefs.GetInt("Quete") + 1;
        Debug.Log("currentQueteNumber " + currentQueteNumber);

        PlayerPrefs.SetInt("Quete", currentQueteNumber);

        SearchQuete();
        transform.GetChild(0).gameObject.SetActive(false);
        
    }

    void Update()
    {
        
    }
}
