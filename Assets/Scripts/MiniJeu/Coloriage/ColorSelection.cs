using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSelection : MonoBehaviour
{

    [SerializeField] Color color1;
    [SerializeField] Color color2;
    [SerializeField] Color color3;
    [SerializeField] Color color4;
    [SerializeField] Color color5;

    [SerializeField] GameObject Contour;

    [SerializeField] GameObject GO_color1;
    [SerializeField] GameObject GO_color2;
    [SerializeField] GameObject GO_color3;
    [SerializeField] GameObject GO_color4;
    [SerializeField] GameObject GO_color5;

    public static Color currentColor = Color.white;

    private void Start()
    {
        currentColor = color1;
        Contour.transform.localPosition = GO_color1.transform.localPosition;
    }

    public void ChooseColor1()
    {
        currentColor = color1;
        Contour.transform.localPosition = GO_color1.transform.localPosition;

    }
    public void ChooseColor2()
    {
        currentColor = color2;
        Contour.transform.localPosition = GO_color2.transform.localPosition;

    }
    public void ChooseColor3()
    {
        currentColor = color3;
        Contour.transform.localPosition = GO_color3.transform.localPosition;

    }
    public void ChooseColor4()
    {
        currentColor = color4;
        Contour.transform.localPosition = GO_color4.transform.localPosition;

    }
    public void ChooseColor5()
    {
        currentColor = color5;
        Contour.transform.localPosition = GO_color5.transform.localPosition;

    }

}
