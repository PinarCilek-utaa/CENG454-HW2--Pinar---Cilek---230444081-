// FlightController.cs
// CENG 454 – HW1: Sky-High Prototype
// Author: [Pınar Çilek] | Student ID: [230444081]


using UnityEngine;

public class FlightController : MonoBehaviour
{
    [SerializeField] private float pitchSpeed  = 45f;  // degrees/second
    [SerializeField] private float yawSpeed    = 45f;  // degrees/second
    [SerializeField] private float rollSpeed   = 45f;  // degrees/second
    [SerializeField] private float thrustSpeed = 5f;   // units/second
    // TODO (Task 3-A): Declare a private Rigidbody field named 'rb'
    //Answer:
    private Rigidbody rb;

    void Start()
    {
        // TODO (Task 3-B): Cache GetComponent<Rigidbody>() into 'rb'.
        //                  Then set rb.freezeRotation = true.
        //                  Why is freezeRotation needed? Answer in your PDF.
        //Answer:
        rb=GetComponent<Rigidbody>();
        rb.freezeRotation=true;
}
void Update()// or FixedUpdate()
    {
        HandleRotation();
        HandleThrust();
    }
    private void HandleRotation()
    {
        // TODO (Task 3-C):
        // Pitch
        //Answer:
        float pitchInput=Input.GetAxis("Vertical");
        transform.Rotate(Vector3.right * pitchInput * pitchSpeed * Time.deltaTime);
        //Yaw
        //Answer:
        float yawInput= Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * yawInput * yawSpeed * Time.deltaTime);
        //Roll
        //Answer:
        float rollInput= 0f;
        if (Input.GetKey(KeyCode.Q)) {rollInput= 1f;}
        if (Input.GetKey(KeyCode.E)) {rollInput = -1f;}
        transform.Rotate(Vector3.forward * rollInput * rollSpeed *Time.deltaTime);
}
    private void HandleThrust()
    {
        // TODO (Task 3-D)
        //Answer:
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.forward * thrustSpeed * Time.deltaTime);
        }
    }
}