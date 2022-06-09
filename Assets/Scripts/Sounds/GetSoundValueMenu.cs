using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetSoundValueMenu : MonoBehaviour
{
    public Slider sliderMenu;
    public Slider slider2Menu;
    public static float MusicValue;
    public static float EffectValue;

    void Start()
    {
        if (GetSoundScript.firstTest)
        {
            sliderMenu.value = GetSoundScript.MusicValueIG;
            slider2Menu.value = GetSoundScript.EffectValueIG;
        }
        else
        {
            sliderMenu.value = 0.2F;
            slider2Menu.value = 0.2F;
        }
    }


    void Update()
    {
        MusicValue = sliderMenu.value;
        EffectValue = slider2Menu.value;
    }
}
