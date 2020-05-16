using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    public float speed = 20f;//移动速度
    private int maxHealth = 5;//最大生命值
    private int currentHealth;//当前生命值
    Rigidbody2D rbody;
    private float invincibleTime = 2f;//无敌时间
    private float invincivleTimer;//无敌计时器
    private bool isInvincible;
    private Vector2 lookDirction = new Vector2(1, 0);//玩家朝向，默认朝右
    Animator anim;
    public GameObject bulletProfab;//子弹

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        invincivleTimer = 0;
        currentHealth = 2;
        rbody = GetComponent<Rigidbody2D>();

        UIManger.instance.UpdateHealthBar(currentHealth, maxHealth);//更新血量
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");//水平A：-1 D：1 0
        float moveY = Input.GetAxisRaw("Vertical");//垂直S：-1 W：1 0

        Vector2 moveVector = new Vector2(moveX, moveY);
        if(moveVector.x!=0 || moveVector.y != 0) {
            lookDirction = moveVector;
        }
        anim.SetFloat("Look X", lookDirction.x);
        anim.SetFloat("Look Y", lookDirction.y);
        anim.SetFloat("Speed", moveVector.magnitude);

        Vector2 position = rbody.position;
        //position.x += moveX * speed * Time.deltaTime;
        //position.y += moveY * speed * Time.deltaTime;
        position += moveVector * speed * Time.deltaTime;
        rbody.MovePosition(position);
        if (isInvincible)
        {
            invincivleTimer -= Time.deltaTime;
            if (invincivleTimer < 0)
            {
                isInvincible = false;
            }
        }

        //按下J键进行攻击
        if (Input.GetKeyDown(KeyCode.J)) {
            anim.SetTrigger("Launch");
            GameObject bullet = Instantiate(bulletProfab, rbody.position+Vector2.up*0.5f, Quaternion.identity);
            BulletController bc = bullet.GetComponent<BulletController>();
            if (bc != null) {
                bc.Move(lookDirction, 300);
            }
        }
    }

    public int getCurrentHealth()
    {
        return currentHealth;
    }
    public int getMaxHealth()
    {
        return maxHealth;
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible == true) return;
            isInvincible = true;
            anim.SetTrigger("Hit");
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        UIManger.instance.UpdateHealthBar(currentHealth, maxHealth);//更新血量

        Debug.Log(currentHealth);
        invincivleTimer = invincibleTime;
    }
}
