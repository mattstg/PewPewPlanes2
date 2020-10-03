using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BasicUnit
{
    public static Player player;
    Bounds allowedBounds;
    protected override bool isPlayer => true;
    protected override void Awake()
    {
        player = this;
        GameObject playerBounds = GameObject.FindGameObjectWithTag("PlayerBounds");
        allowedBounds = playerBounds.GetComponent<SpriteRenderer>().bounds;
        GameObject.Destroy(playerBounds);
        base.Awake();
    }
    protected override void Update()
    {
        base.Update();
        LockInBounds();
        if (Input.GetKey(KeyCode.Space))
            Shoot();
    }

    private void LockInBounds()
    {
        if (!allowedBounds.Contains(transform.position))
        {
            Vector2 newPos = transform.position;
            newPos.x = Mathf.Clamp(newPos.x, allowedBounds.center.x - allowedBounds.extents.x, allowedBounds.center.x + allowedBounds.extents.x);
            newPos.y = Mathf.Clamp(newPos.y, allowedBounds.center.y - allowedBounds.extents.y, allowedBounds.center.y + allowedBounds.extents.y);
            transform.position = newPos;
        }
    }
    protected override Vector2 GetMoveDir()
    {
        return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    

}
