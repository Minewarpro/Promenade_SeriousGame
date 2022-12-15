using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeScene : MonoBehaviour
{

    [SerializeField] string sceneName;
    [SerializeField] Vector3 spawn;
    public static Vector3 spawnPos;
    [SerializeField] public static bool staticChangePos;
    [SerializeField] bool changePos;

    private void OnTriggerEnter(Collider other)
    {
        spawnPos = spawn;

        SceneManager.LoadScene(sceneName);
        staticChangePos = changePos;
    }

    
    void Start()
    {
    }


    void Update()
    {
        
    }
}
