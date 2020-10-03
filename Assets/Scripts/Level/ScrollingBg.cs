using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBg : MonoBehaviour
{
    public Vector2 scrollDirectionAndSpeed;
    Vector2 offset;
    SpriteRenderer sr;

    // Start is called before the first frame update
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        offset += scrollDirectionAndSpeed * Time.deltaTime;
        sr.material.SetTextureOffset("_MainTex", offset);
    }
}
