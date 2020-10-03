using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldLinks : MonoBehaviour
{
    public static WorldLinks instance;
    public SpriteRenderer background;
    public Player player;
    public GameObject bulletInstance;
    [HideInInspector]public Bounds worldBounds;
    private void Awake()
    {
        worldBounds = background.bounds;
        instance = this;
    }
    
}
