using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider2D;

    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Open()
    {
        boxCollider2D.enabled = false;
        spriteRenderer.color = new Color(1, 1, 1, 0.5f);
    }

    public void Close()
    {
        boxCollider2D.enabled = true;
        spriteRenderer.color = new Color(1, 1, 1, 1f);
    }
}
