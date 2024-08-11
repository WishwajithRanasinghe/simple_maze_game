using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;
    private Animator _animator;
    private Rigidbody _rBody;
    private bool _isHasKey;
    

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 input;
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(input.x, 0, input.y);
        movement = movement.normalized;

        _rBody.position = transform.position + movement* moveSpeed * Time.deltaTime;

        Vector3 directionFoword = Vector3.RotateTowards(transform.forward, new Vector3(input.x, 0, input.y), rotateSpeed * Time.deltaTime,0f);
        Quaternion rotation = Quaternion.LookRotation(directionFoword);
        transform.rotation = rotation;

        _animator.SetBool("IsRun", (movement.magnitude > 0));

        if(movement.magnitude <= 0)
        {
            _rBody.velocity = Vector2.zero;
            _rBody.angularVelocity = Vector2.zero;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Key")
        {
            collision.gameObject.SetActive(false);
            _isHasKey = true;

        }
        if(collision.transform.tag == "Door")
        {
            if (_isHasKey)
            {
                collision.gameObject.SetActive(false);
            }
            

        }
    }
}
