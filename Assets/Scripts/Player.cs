using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float powerupSpeed = 2f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private float groundDist = 0.4f;
    [SerializeField] private LayerMask groundMask;

    public bool IsPoweredUp { get; private set; }

    private float powerupTime = 0f;
    private bool grounded = true;
    private new Rigidbody2D rigidbody2D;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        rigidbody2D = GetComponent<Rigidbody2D>();

        GameManager.SetPlayer(this);
    }

    private void Update()
    {
        float inputX = Input.GetAxis("Horizontal");

        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            grounded = false;
            audioSource.PlayOneShot(jumpSound);
        }

        if (IsPoweredUp)
        {
            powerupTime -= Time.deltaTime;
        }
        IsPoweredUp = powerupTime > 0f;

        float finalSpeed = moveSpeed;
        if (IsPoweredUp)
        {
            finalSpeed = powerupSpeed;
        }

        rigidbody2D.velocity = Vector2.right * inputX * finalSpeed + Vector2.up * rigidbody2D.velocity.y;
    }

    private void FixedUpdate()
    {
        grounded = Physics2D.BoxCast(transform.position, Vector2.one, 0, Vector2.down, groundDist, groundMask);
    }

    public void AddPowerupTime(float duration)
    {
        powerupTime += duration;
    }
}
