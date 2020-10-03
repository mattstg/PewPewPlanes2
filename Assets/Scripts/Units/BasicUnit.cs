using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicUnit : MonoBehaviour
{
    public float speed;
    public float cooldown;
    public BulletType bulletType;

    float timeNextValidShoot;
    protected virtual bool isPlayer => false;

    protected virtual void Awake()
    {
        
    }
    
    public virtual void DestroyUnit()
    {
        GameObject.Destroy(gameObject);

    }
    protected virtual void Update()
    {
        Move(GetMoveDir().normalized);
    }

    protected virtual Vector2 GetMoveDir()
    {
        return Vector2.zero;
    }

    protected virtual void Move(Vector2 moveDir)
    {
        transform.position = (Vector2)transform.position + moveDir * Time.deltaTime * speed;
    }

    protected void Shoot()
    {
        if(timeNextValidShoot <= Time.time)
        {
            timeNextValidShoot = Time.time + cooldown;
            GameObject.Instantiate(WorldLinks.instance.bulletInstance).GetComponent<Bullet>().Initialize(!isPlayer, transform.position);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.Destroy(gameObject);
    }
}
