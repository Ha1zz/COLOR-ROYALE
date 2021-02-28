using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{

    public float movementSpeed = 5;
    public float jumpForce = 300;
    public float timeBeforeNextJump = 1.2f;
    private float canJump = 0f;
    private Vector2 inputVector = Vector2.zero;
    private Vector2 lookVector = Vector2.zero;
    private Vector3 moveDirection = Vector3.zero;
    private Vector2 rot;

    Animator anim;
    Rigidbody rb;
    Transform playerTransform;
    InputValue value;

    //
    public GameObject pauseLabel;
    public GameObject instructionLabel;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        playerTransform = GetComponent<Transform>();
    }

    void Update()
    {
        ControllPlayer();
    }

    private void LateUpdate()
    {
        Vector3 movementDirection = moveDirection * (movementSpeed * Time.deltaTime);

        playerTransform.position += movementDirection;

        GetComponent<Transform>().Rotate(Vector3.up * lookVector.x * .2f);
    }

    public void OnMovement(InputValue value)
    {
        inputVector = value.Get<Vector2>();

        anim.SetInteger("Walk", 1);
    }

    public void OnPause(InputValue action)
    {
        Time.timeScale = 0;
        pauseLabel.SetActive(true);
    }

    public void OnInstruction(InputValue action)
    {
        Time.timeScale = 0;
        instructionLabel.SetActive(true);
    }

    public void OnLook(InputValue value)
    {
        lookVector = value.Get<Vector2>();
        anim.SetInteger("Walk", 1);
    }

    void ControllPlayer()
    {
        if (!(inputVector.magnitude > 0)) moveDirection = Vector3.zero;

        moveDirection = playerTransform.forward * inputVector.y + playerTransform.right * inputVector.x;



        //Vector3 movementDirection = moveDirection * (movementSpeed * Time.deltaTime);

        //playerTransform.position += movementDirection;

        //GetComponent<Transform>().Rotate(Vector3.up * lookVector.x * .2f);

    }
}