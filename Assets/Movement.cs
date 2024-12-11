using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;  
    public float jumpHeight = 2f;
    public float gravity = -9.81f; 

    private CharacterController controller; 
    private Vector3 velocity; 
    private bool isGrounded,isLadder;
    [SerializeField] Camera KameraGracza;
    int displayTarget = 1;
    Vector3 LastCheckpoint;
    private bool isTeleporting = false, isWater = false;
    public static event Action<IInteract> InteractEvent;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        isLadder = false;
    }
    void FixedUpdate()
    {

        if (!isTeleporting) 
        {
            Vector3 position = transform.position;
            position.z = 7.12f; 
            transform.position = position;
        }
    }
    void Update()
    {
        isGrounded = controller.isGrounded;

        if (!isLadder && isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float horizontal = -Input.GetAxis("Horizontal");
        Vector3 move = new Vector3(horizontal, 0, 0);

        if (isLadder)
        {

            float vertical = Input.GetAxis("Vertical"); 
            move.y = vertical * moveSpeed;
            velocity.y = 0; 
        }
        else if (isWater)
        {
            float vertical = Input.GetAxis("Vertical");
            move.y = vertical * moveSpeed/8;
            velocity.y = -.4f;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }

        controller.Move(move * moveSpeed * Time.deltaTime);
        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isLadder)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log(transform.position);
            if (displayTarget == 1)
            {
                displayTarget = 0;
            }
            else
            {
                displayTarget = 1;
            }
            KameraGracza.targetDisplay = displayTarget;
            Debug.Log(displayTarget);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            transform.SetParent(collision.transform);
        }

    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Checkpoint"))
        {
            LastCheckpoint = transform.position;
            Debug.Log($"Checkpoint updated to: {LastCheckpoint}");
        }
        if (collision.gameObject.CompareTag("Trap"))
        {
            StartCoroutine(TeleportToCheckpoint());
        }
        if (collision.gameObject.CompareTag("Interact"))
        {
            // Sprawdź, czy obiekt ma komponent implementujący IInteractable
            IInteract interactable = collision.GetComponent<IInteract>();

            if (interactable != null)
            {
                Debug.Log("Wszedłeś w strefę interakcji.");
                InteractEvent?.Invoke(interactable); // Wywołaj event i przekaż obiekt interaktywny
                
            }
  
        }
        if (collision.gameObject.CompareTag("Ladder"))
        {
            Debug.Log("LADDERRRRR");
            isLadder = true;
        }
        if (collision.gameObject.CompareTag("Water"))
        {
           
            isWater = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            transform.SetParent(null);
        }
    }
    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            isLadder = false;
        }
        if (collision.gameObject.CompareTag("Water"))
        {
            isWater = false;
        }
    }
    private IEnumerator TeleportToCheckpoint()
    {
        isTeleporting = true;
        controller.enabled = false;
        transform.position = LastCheckpoint;
        Debug.Log($"Teleported to: {LastCheckpoint}, object: {gameObject.name}");
        yield return null;
        controller.enabled = true;
        isTeleporting = false;
    }

}
