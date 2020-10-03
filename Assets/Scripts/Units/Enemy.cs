using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BasicUnit
{
    List<Vector2> path;
    int currentIndex;
    Player p;
    public void InitializeEnemy(List<Vector2> path)
    {
        this.path = path;
        transform.position = path[0];
    }

    protected override void Update()
    {
        base.Update();
        Shoot();
        if (Vector2.SqrMagnitude((Vector2)transform.position - path[currentIndex]) < .01f)
        {
            currentIndex++;
            if(currentIndex >= path.Count)
            {
                DestroyUnit();
            }
        }
    }

    protected override Vector2 GetMoveDir()
    {
        return path[currentIndex] - (Vector2)transform.position;
    }

}
