using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kid_Run : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] float delayTurn;
    private bool move = true;


    void Start()
    {
        StartCoroutine(Turn());
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            move = false;
            StopCoroutine(Turn());
        }
    }


    private IEnumerator Turn()
    {
        if (move)
        {
            transform.Rotate(0,90,0);
        }
        yield return new WaitForSeconds(delayTurn);
        StartCoroutine(Turn());
    }

    void Update()
    {
        if (move)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
