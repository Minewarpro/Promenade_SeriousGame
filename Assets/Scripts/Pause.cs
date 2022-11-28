using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;


public class Pause : MonoBehaviour
{

    [SerializeField] GameObject ONButtonVolume; 
    [SerializeField] Image ONImageVolume; 
    
    [SerializeField] GameObject ONButtonMusique; 
    [SerializeField] Image ONImageMusique;

    [SerializeField] GameObject joystick;

    private void Start()
    {
        
    }

    public void PauseButton()
    {
        gameObject.SetActive(true);
        Vector3 initScale = transform.localScale;
        transform.localScale *= 0.8f;
        transform.DOScale(initScale, 0.7f).SetEase(Ease.OutBack);

        joystick.transform.GetChild(0).GetComponent<Image>().raycastTarget = false;
        joystick.GetComponent<Image>().raycastTarget = false;
    }

    public void PlayButton()
    {
        gameObject.SetActive(false);
        joystick.transform.GetChild(0).GetComponent<Image>().raycastTarget = true;
        joystick.GetComponent<Image>().raycastTarget = true;
    }

    public void HomeButton()
    {
        SceneManager.LoadScene("Menu");
    }

    public void VolumeButton()
    {
        float fillAmount = ONImageVolume.fillAmount;

        if (fillAmount == 0)
        {
            ONButtonVolume.transform.DOMoveX(ONButtonVolume.transform.position.x + 0.520f, 0.5f);
            ONImageVolume.DOFillAmount(1, 0.5f);
            AudioListener.volume = 1;
        }
        else if (fillAmount == 1)
        {
            ONButtonVolume.transform.DOMoveX(ONButtonVolume.transform.position.x - 0.520f, 0.45f);
            ONImageVolume.DOFillAmount(0, 0.5f);
            AudioListener.volume = 0;
        }
    }

    public void MusiqueButton()
    {
        float fillAmount = ONImageMusique.fillAmount;

        if (fillAmount == 0)
        {
            ONButtonMusique.transform.DOMoveX(ONButtonMusique.transform.position.x + 0.520f, 0.5f);
            ONImageMusique.DOFillAmount(1, 0.5f);
        }
        else if (fillAmount == 1)
        {
            ONButtonMusique.transform.DOMoveX(ONButtonMusique.transform.position.x - 0.520f, 0.45f);
            ONImageMusique.DOFillAmount(0, 0.5f);
        }
    }
}
