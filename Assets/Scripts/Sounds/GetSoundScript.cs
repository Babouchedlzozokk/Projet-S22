using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetSoundScript : MonoBehaviour
{
    public Slider sliderGame;
    public Slider slider2Game;
    public static float MusicValueIG;
    public static float EffectValueIG;
    public static bool firstTest = false;
   
    void Start()
    {
        sliderGame.value = GetSoundValueMenu.MusicValue;
        slider2Game.value = GetSoundValueMenu.EffectValue;
        firstTest = true;
    }

    void Update()
    {
        MusicValueIG = sliderGame.value;
        EffectValueIG = slider2Game.value;
    }
}
