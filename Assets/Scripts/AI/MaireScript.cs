using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MaireScript : MonoBehaviour
{
    [SerializeField] public List<GameObject> trajectoireList;
    [SerializeField] public GameObject nextQuest;
    [SerializeField] Image BlackScreen;



    private int nbTrajet = 0;


    public void StartWalk()
    {
        if (nbTrajet < trajectoireList.Count)
        {
            transform.DOMove(trajectoireList[nbTrajet].transform.position, 1f).SetEase(Ease.Linear).OnComplete(() => StartWalk());
            nbTrajet += 1;
        } else
        {
            nextQuest.SetActive(true);
        }
    }


    public void StartMiniGame()
    {
        BlackScreen.GetComponent<CanvasGroup>().DOFade(1f, 0.5f).OnComplete(() =>
        {
            SceneManager.LoadScene("MiniGameMarteau");
        });
    }

    private void Update()
    {

    }
}
