using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class Kid_Run : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] float delayTurn;
    private bool move = true;
    private bool step2 = false;
    private RaycastHit Hit;

    [SerializeField] private string newText;
    [SerializeField] private GameObject TextContainer;
    [SerializeField] private GameObject joystickContainer;
    [SerializeField] private GameObject nextQuest;
    PlayerController player;


    void Start()
    {
        StartCoroutine(Turn());
        player = FindObjectOfType<PlayerController>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            move = false;
            StopCoroutine(Turn());

            if (step2)
            {
                move = false;
                nextQuest.SetActive(true);
            }
        }
    }

    public void TextApparition()
    {
            player.canMove = false;
            TextContainer.gameObject.SetActive(true);
            TextContainer.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = newText;
            joystickContainer.SetActive(false);
        nextQuest.SetActive(false);

    }

    public void TextClose()
    {
        player.canMove = true;
        TextContainer.gameObject.SetActive(false);
        joystickContainer.SetActive(true);
        nextQuest.SetActive(false);
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

    private IEnumerator RandomWalk()
    {
        transform.Rotate(Vector3.up * Random.Range(30, 180));

        yield return new WaitForSeconds(Random.Range(0f, 3f));
        StartCoroutine(RandomWalk());
    }

    public void StartRace()
    {
        step2 = true;
        move = true;
        StartCoroutine(RandomWalk());
        speed = 7;
    }

    void Update()
    {
        if (move)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit, 3) && step2)
            {
                transform.Rotate(Vector3.up * Random.Range(30, 180));
            }
        }
    }
}
