using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

    [SerializeField] private Text txtPathSetting;
    [SerializeField] private Text txtSpeed;
    [SerializeField] private Slider sliderSpeed;
    // Start is called before the first frame update
    void Awake()
    {
        //txtPathSetting = GetComponent<Text>();
        //txtSpeed = GetComponent<Text>();
    }

    public void setSliderSpeed(int val)
    {
        sliderSpeed.value = val;
    }

    public void setTxtPathSetting(string txt)
    {
        txtPathSetting.text = txt;
    }

    public Text getTxtPathSetting()
    {
        return txtPathSetting;
    }

    public void setTxtSpeed(string aSpeed)
    {
        txtSpeed.text = "Speed = " + aSpeed;
    }
}
