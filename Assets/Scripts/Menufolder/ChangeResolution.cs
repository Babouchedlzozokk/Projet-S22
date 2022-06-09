using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeResolution : MonoBehaviour
{
    public Dropdown DResolution;
    public Toggle FToggle;

    public void SetResolution()
    {
        switch (DResolution.value)
        {
            case 0:
                Screen.SetResolution(1920,1080,Screen.fullScreen);
                break;
            case 1:
                Screen.SetResolution(1680, 1050, Screen.fullScreen);
                break;
            case 2:
                Screen.SetResolution(1600, 900, Screen.fullScreen);
                break;
            case 3:
                Screen.SetResolution(1400, 1050, Screen.fullScreen);
                break;
            case 4:
                Screen.SetResolution(1366, 768, Screen.fullScreen);
                break;
            case 5:
                Screen.SetResolution(1280, 960, Screen.fullScreen);
                break;
            case 6:
                Screen.SetResolution(1024, 728, Screen.fullScreen);
                break;
            case 7:
                Screen.SetResolution(800, 600, Screen.fullScreen);
                break;
        }
    }

    public void setFullScreen()
    {
        Screen.fullScreen = FToggle.isOn;
    }
}
