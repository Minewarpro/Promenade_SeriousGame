using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kid_Run : MonoBehaviour
{

    [SerializeField] float speed;


    void Start()
    {
        
    }

    private IEnumerator RandomWalk()
    {
        transform.Rotate(0,90,0);

        yield return new WaitForSeconds(Random.Range(0f, 8f));
        StartCoroutine(RandomWalk());
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
