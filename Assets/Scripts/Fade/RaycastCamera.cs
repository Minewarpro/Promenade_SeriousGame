using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RaycastCamera : MonoBehaviour
{
    private PlayerController player;
    //private GameObject ObjectHit;
    [SerializeField] LayerMask occluder;
    [SerializeField] public List<MeshRenderer> objectHited = new List<MeshRenderer>();    

    private void ThrowRaycast()
    {
        Vector3 playerPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);


        Vector3 direction = (playerPos - Camera.main.transform.position).normalized;
        Ray ray = new Ray(Camera.main.transform.position, direction);
       
        // contient l'objet touché par le raycast
        RaycastHit hit;
        // condition lu si touché par le raycast

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Debug.Log(occluder.value);

            if (hit.transform.gameObject.layer == 6 )
            {
                MeshRenderer ObjectHit = hit.transform.gameObject.GetComponent<MeshRenderer>();

                if (ObjectHit.material.color.a == 1)
                {
                    objectHited.Add(ObjectHit);
                }

                for (int i = 0; i < ObjectHit.materials.Length; i++)
                {
                    if (ObjectHit.materials[i].color.a == 1)
                    {
                        MaterialExtensions.ToFadeMode(ObjectHit.materials[i]);
                        ObjectHit.materials[i].DOFade(0.5f, 0.5f);
                    }
                }
                Debug.Log(objectHited.Count);
            } else
            {
                for (int i = 0; i < objectHited.Count; i++)
                {
                    for (int y = 0; y < objectHited[i].materials.Length; y++)
                    {
                        if (objectHited[i].materials[y].color.a != 1f)
                        {
                            MaterialExtensions.ToOpaqueMode(objectHited[i].materials[y]);
                            objectHited[i].materials[y].DOFade(1f, 0.5f);
                        }
                    }
                }
                objectHited.Clear();

            }
        }
       
    }

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        ThrowRaycast();
    }
}
