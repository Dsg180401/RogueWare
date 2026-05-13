using System;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Sprite doorOpen, doorClose;
    public bool isOpen;

    private BoxCollider2D collision;
    private SpriteRenderer renderer;

    private void Start()
    {
        collision = GetComponent<BoxCollider2D>();
        renderer = GetComponent<SpriteRenderer>();

        // Set correct state on start
        if (isOpen)
            Open();
        else
            Close();
    }

    public void Open()
    {
        if (isOpen) return;

        isOpen = true;

        renderer.sprite = doorOpen;
        collision.enabled = false;
    }

    public void Close()
    {
        if (!isOpen) return;

        isOpen = false;

        renderer.sprite = doorClose;
        collision.enabled = true;
    }
}