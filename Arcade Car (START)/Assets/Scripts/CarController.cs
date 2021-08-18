using System;
using UnityEngine;

public class CarController : MonoBehaviour
{
    // Rigidbody có tác dụng điều khiển vị trí của vật thể thông qua hệ thống mô phỏng vật lý của Unity,
    // không cần bất kỳ script nào nó cũng có thể di chuyển và xử lý hướng khi va chạm (nếu có Collider)

    public Rigidbody carRigidBody;

    public float forward = 8, reverse = 4, maxSpeed = 50, turnStrength = 180, gravityForce = 10f;

    private float turnInput, speedInput;

    private bool grounded;

    public LayerMask isGround;
    public float groundRayLength = 0.5f;
    public Transform groundRayPoint;

    private void Start()
    {
        carRigidBody.transform.parent = null;
    }

    public void Update()
    {
        // Tốc độ tiến/ lùi

        speedInput = 0;
        var verticalInput = Input.GetAxis("Vertical");

        if (verticalInput > 0)
            speedInput = verticalInput * forward * 1000;
        else if (verticalInput < 0)
            speedInput = verticalInput * reverse * 1000;

        // Tốc độ xoay
        turnInput = Input.GetAxis("Horizontal");

        if (grounded)
        {
            transform.rotation =
                Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0,
                    turnInput * turnStrength * Time.deltaTime * verticalInput, 0));
        }

        transform.position = carRigidBody.transform.position;
    }

    private void FixedUpdate()
    {
        grounded = false;

        RaycastHit hit;

        if (Physics.Raycast(groundRayPoint.position, -transform.up, out hit, groundRayLength, isGround))
        {
            grounded = true;
        }

        if (grounded)
        {
            if (Mathf.Abs(speedInput) > 0)
                carRigidBody.AddForce(transform.forward * speedInput);
        }
        else
        {
            carRigidBody.AddForce(Vector3.up * -gravityForce * 100f);
        }

    }
}