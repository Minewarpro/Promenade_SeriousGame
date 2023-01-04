using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BullDiscution : MonoBehaviour
{
    [SerializeField] string newText;
    [SerializeField] GameObject textContainer;
    [SerializeField] GameObject joystick;

    [SerializeField] GameObject text;

    public void OnClickButton()
    {
        textContainer.SetActive(true);
        joystick.SetActive(false);
        text.GetComponent<TextMeshProUGUI>().text = newText;
    }
}
