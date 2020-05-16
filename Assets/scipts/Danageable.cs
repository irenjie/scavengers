using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//伤害碰撞
public class Danageable : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
        PlayerControll pc = other.GetComponent<PlayerControll>();
        if (pc != null)
        {
            pc.ChangeHealth(-1);
        }
    }
}