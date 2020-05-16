using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//UI管理相关
public class UIManger : MonoBehaviour
{
    //单例模式
    public static UIManger instance { get; private set; }
    public Image healthBar;//角色血条

    void Awake() {
        instance = this;
    }

    public void UpdateHealthBar(int curAmount,int maxAmount) {
        healthBar.fillAmount =(float) curAmount / (float)maxAmount;
    }
}
