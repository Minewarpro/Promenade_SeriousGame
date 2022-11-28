using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySingleton : Singleton<MySingleton>
{
    public int currentQuete;
    public List<GameObject> QuetesList;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init()
    {
        currentQuete = PlayerPrefs.GetInt("Quete");
        Debug.Log("Singleton");
    }

}
