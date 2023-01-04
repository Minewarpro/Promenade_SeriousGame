using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Basic1 : MonoBehaviour
{
    [SerializeField] GameObject hair;
    [SerializeField] List<Material> hairs;



    [SerializeField] GameObject tshirt;
    [SerializeField] List<Material> tshirts;


    [SerializeField] public float speed = 5;
    private RaycastHit Hit;

    private Animator mAnimator;

    public bool needWalk = true;


    void Start()
    {
        mAnimator = transform.GetChild(0).GetComponent<Animator>();

        if (needWalk)
        {
            StartCoroutine(RandomWalk());
            mAnimator.SetTrigger("Run");
        }
        else
        {
            mAnimator.SetTrigger("Idle");
        }

        hair.GetComponent<Renderer>().materials[1].color = hairs[Random.Range(0, hairs.Count)].color;
        tshirt.GetComponent<MeshRenderer>().materials[0].color = tshirts[Random.Range(0, tshirts.Count)].color;
    }

    private IEnumerator RandomWalk()
    {
        transform.Rotate(Vector3.up * Random.Range(30, 180));

        yield return new WaitForSeconds(Random.Range(0f, 8f));
        StartCoroutine(RandomWalk());
    }

    void Update()
    {
        if (needWalk)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit, 3))
            {
                transform.Rotate(Vector3.up * Random.Range(30, 180));
            }
        }
    }
}
