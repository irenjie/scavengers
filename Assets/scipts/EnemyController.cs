using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3;//移动速度
    public float changeDirectionTime = 2f;
    private float changeTimer;
    public bool isVerrical;//是否垂直方向移动
    public Vector2 moveDirection;//移动方向
    private bool isFixed;
    private Rigidbody2D rbody;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        moveDirection = isVerrical ? Vector2.up : Vector2.right;//如果是垂直移动，方向就朝上，否则方向超右
        changeTimer = changeDirectionTime;
        isFixed = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (isFixed)
            return;
        changeTimer -= Time.deltaTime;
        if (changeTimer < 0) {
            moveDirection *= -1;
            changeTimer = changeDirectionTime;
        }
        Vector2 position = rbody.position;
        position.x += moveDirection.x * speed * Time.deltaTime;
        position.y += moveDirection.y * speed * Time.deltaTime;
        rbody.MovePosition(position);
        anim.SetFloat("moveX", moveDirection.x);
        anim.SetFloat("moveY", moveDirection.y);
    }

    //与玩家的碰撞检测
    void OnCollisionEnter2D(Collision2D other) {
        PlayerControll pc = other.gameObject.GetComponent<PlayerControll>();
        if (pc != null) {
            pc.ChangeHealth(-1);
        }
    }

    public void Fixed() {
        rbody.simulated = false;//禁用物理
        anim.SetTrigger("hit");
    }
}
