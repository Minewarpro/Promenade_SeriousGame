using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject EntireOptionButton;

    private float fillAmount;
    private Image EntireOptionButtonImage;
    private string currentDate = "2022";

    private void Awake()
    {
        currentDate = PlayerPrefs.GetString("CurrentDate", currentDate);
        EntireOptionButtonImage = EntireOptionButton.GetComponent<Image>();
    }

    
    public void OptionButtonSript()
    {
        fillAmount = EntireOptionButton.GetComponent<Image>().fillAmount;

        if (fillAmount == 0)
        {
            EntireOptionButton.transform.DOMoveX(EntireOptionButton.transform.position.x + 10, 0.5f);
            EntireOptionButtonImage.DOFillAmount(1, 0.5f);
        }else if (fillAmount == 1)
        {
            EntireOptionButton.transform.DOMoveX(EntireOptionButton.transform.position.x - 10, 0.45f);
            EntireOptionButtonImage.DOFillAmount(0, 0.5f);
        }
    }

    public void StartButton()
    {
        SceneManager.LoadScene(currentDate);
    }


}
