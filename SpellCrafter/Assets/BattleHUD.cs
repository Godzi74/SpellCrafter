using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Text nameText;
    public Slider hpSlider;
    public Unit getUnit;

    public void SetHUD()
    {
        //sets player and enemy UI to health bar
        nameText.text = getUnit.name;
        hpSlider.maxValue = getUnit.maxHP;
        hpSlider.value = getUnit.curHP;
    }

    void Update()
    {
        SetHUD();
    }
}
