using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float lifetime = 2f;

    private float currLifetime = 2f;
    private bool isColliding = false;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currLifetime = lifetime;
    }

    private void Update()
    {
        if (isColliding)
        {
            currLifetime -= Time.deltaTime;
        }

        Color newColor = spriteRenderer.color;
        newColor.a = currLifetime / lifetime;
        spriteRenderer.color = newColor;

        if (currLifetime <= 0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        isColliding = true;
    }
}
