using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Basic : MonoBehaviour
{

    [SerializeField] public float speed = 5;
    private RaycastHit Hit;

    void Start()
    {
        StartCoroutine(RandomWalk());
    }

    private IEnumerator RandomWalk()
    {
        transform.Rotate(Vector3.up * Random.Range(30, 180));

        yield return new WaitForSeconds(Random.Range(0f, 8f));
        StartCoroutine(RandomWalk());
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime); 

        if(Physics.Raycast(transform.position, transform.TransformDirection (Vector3.forward), out Hit, 3))
        {
            transform.Rotate(Vector3.up * Random.Range(30, 180));
        }
    }
}
