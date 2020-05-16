using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//草莓碰撞相关类
public class Collectable : MonoBehaviour
{
    public AudioClip collectClip;//拾取音效
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //碰撞体检测
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerControll pc = other.GetComponent<PlayerControll>();
        if (pc != null)
        {
            if (pc.getCurrentHealth() != pc.getMaxHealth())
            {
                pc.ChangeHealth(1);
                AudioManger.instance.AudioPlay(collectClip);
                Destroy(this.gameObject);
            }
        }
    }
}
