using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovements : MonoBehaviour
{
    public float speedWalking = 1.5f;
    public float speedRunning = 2.5f;    
    public float jumpHeight = 1f;

    // Private vars
    float speed;
    float speedTarget;

    float groundDistance = 0.25f;
    LayerMask groundLayerMask = 1;
    Vector3 moveDirection;
    Rigidbody rb;

    Vector3 crouch = new Vector3(0.8f,0.5f,0.8f);
    Vector3 stand = new Vector3(0.8f, 1f, 0.8f);


    bool isGrounded;

    float lerpSpeed;

    float vertical, horizontal;

    float lastJumpTime = -10f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        if (GameManager.instance.isGameOver)
            return;

        // Ground check
        // Créer un layer pour le personnage pour qu'il évite de se détecter lui-même
        isGrounded = true; // Physics.CheckSphere(transform.position, groundDistance, groundLayerMask, QueryTriggerInteraction.Ignore);

        

        // Inputs
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

        // Animations de déplacement ========================
        if (Input.GetKey(KeyCode.LeftShift)&&!Input.GetKey(KeyCode.LeftControl))
        {
            // Vitesse de déplacement et animation
            speedTarget = speedRunning;            
        }
        else
        {
            // Vitesse de déplacement et animation
            speedTarget = speedWalking;
        }

        // s'accroupir
        if (Input.GetKey(KeyCode.LeftControl))
        {
            //reduit son scale en hauteur
            transform.localScale = crouch;
        }
        else
        {
            //garde sa hauteur
            transform.localScale = stand;
        }
            // Interpolations
            lerpSpeed = Time.deltaTime * 5f;

        speed = Mathf.Lerp(speed, speedTarget, lerpSpeed);
        // ===================================================

        // Déplacements
        moveDirection = transform.forward * vertical;
        moveDirection += transform.right * horizontal;

        // ------------------------------------------------------------

        // Jump -------------------------------------------------------
        if (Input.GetButtonDown("Jump") && Time.time > lastJumpTime + 1.25f)
        {            
            Jump();
            lastJumpTime = Time.time;
        }

        // Respawn ------------------------------------------------
        if (transform.position.y < 0f)
            GameManager.instance.GameOver();
    }

    public void Jump()
    {
        rb.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
    }

    private void FixedUpdate()
    {        
        rb.MovePosition(rb.position + moveDirection * speed * Time.fixedDeltaTime);
    }
}
