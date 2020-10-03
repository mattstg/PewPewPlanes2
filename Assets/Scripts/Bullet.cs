using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    bool enemyBullet;
    public void Initialize(bool enemyBullet, Vector2 startPos)
    {
        transform.position = startPos;
        this.enemyBullet = enemyBullet;
        gameObject.layer = (enemyBullet) ? LayerMask.NameToLayer("EnemyBullet") : LayerMask.NameToLayer("PlayerBullet");
    }

    private void Update()
    {
        transform.position += (Vector3.up * speed * ((enemyBullet) ?-1:1)) * Time.deltaTime;
        if (!WorldLinks.instance.worldBounds.Contains(transform.position))
            GameObject.Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //collision.gameObject.GetComponent<BasicUnit>().DestroyUnit();
        GameObject.Destroy(gameObject);
    }
}
