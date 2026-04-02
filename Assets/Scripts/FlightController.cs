// FlightController.cs
// CENG 454 – HW1: Sky-High Prototype
// Author: [Pınar Çilek] | Student ID: [230444081]

using UnityEngine;

public class FlightController : MonoBehaviour
{
    [SerializeField] private float pitchSpeed  = 45f;  
    [SerializeField] private float yawSpeed    = 45f;  
    [SerializeField] private float rollSpeed   = 45f;  
    [SerializeField] private float thrustForce = 50f;   

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    //We use `fixedUpdate` and `timaeFixeddeltatiem` for physics calculations and to ensure the aircraft doesn't pierce any ground.
    
    void FixedUpdate() 
    {
        HandleRotation();
        HandleThrust();
    }

    private void HandleRotation()
    {
        float pitchInput = Input.GetAxis("Vertical");
        transform.Rotate(Vector3.right * pitchInput * pitchSpeed * Time.fixedDeltaTime);

        float yawInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * yawInput * yawSpeed * Time.fixedDeltaTime);

        float rollInput = 0f;
        if (Input.GetKey(KeyCode.Q)) { rollInput = 1f; }
        if (Input.GetKey(KeyCode.E)) { rollInput = -1f; }
        transform.Rotate(Vector3.forward * rollInput * rollSpeed * Time.fixedDeltaTime);
    }

    private void HandleThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(transform.forward * thrustForce, ForceMode.Acceleration);
        }
        else
        {
            rb.linearVelocity = Vector3.Lerp(rb.linearVelocity, Vector3.zero, Time.fixedDeltaTime * 2f);
        }
    }
}