using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float Speed = 7f;
    public float JumpHeight = 4f;
    public float Gravity = -9.81f;
    public float GroundDistance = .2f;
    public float DashDistance = 5f;
    public LayerMask Ground;
    public Vector3 Drag;

    private CharacterController _controller;
    private Vector3 _velocity;
    private bool _isGrounded = true;
    private Transform _groundChecker;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _groundChecker = transform.GetChild(0);
        GroundDistance = GetComponent<SphereCollider>().radius;
    }

    void Update()
    {
        //Collide with the ground
        _isGrounded = Physics.CheckSphere(transform.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);
        Debug.Log("Position? " + transform.position);
        Debug.Log("Grounded? " + _isGrounded);
        if (_isGrounded && _velocity.y < 0)
            _velocity.y = 0f;

        //Move Horizontally
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        _controller.Move(move * Time.deltaTime * Speed);
        if (move != Vector3.zero) {
            Debug.Log("Moving!");
            //transform.forward = move;
        }
            

        //Jump
        if (Input.GetButtonDown("Vertical") && _isGrounded)
        {
            Debug.Log("Jumping!");
            _velocity.y += Mathf.Sqrt(JumpHeight * -2f * Gravity);
            _isGrounded = false;
        }
        else if(!_isGrounded)
        {
            Debug.Log("Not Grounded!");
        }

        _velocity.y += Gravity * Time.deltaTime;

        _velocity.x /= 1 + Drag.x * Time.deltaTime;
        _velocity.y /= 1 + Drag.y * Time.deltaTime;
        _velocity.z /= 1 + Drag.z * Time.deltaTime;
        Debug.Log("Jump Velocity: " + _velocity.y);
        _controller.Move(_velocity * Time.deltaTime);
    }

}
