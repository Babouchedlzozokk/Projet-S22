using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class printCtrl : MonoBehaviour
{
    public Text Forward;
    public Text Back;
    public Text Left;
    public Text Right;
    public Text Jump;
    public Text Sprint;
    public Text shoot;
    public Text Grapplin;
    public Text BackInTime;
    public Text Dash;
    public Text Reload;

    private void Update()
    {
        Forward.text = (INPUTS.forward).ToString();
        Back.text = (INPUTS.back).ToString();
        Left.text = (INPUTS.left).ToString();
        Right.text = (INPUTS.right).ToString();
        Jump.text = (INPUTS.Jump).ToString();
        Sprint.text = (INPUTS.sprint).ToString();
        shoot.text = (INPUTS.tir_principal).ToString();
        Grapplin.text = (INPUTS.tir_secondaire).ToString();
        BackInTime.text = (INPUTS.Back_in_time).ToString();
        Dash.text = (INPUTS.dash).ToString();
        Reload.text = (INPUTS.reload).ToString();
    }
}
