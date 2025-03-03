using UnityEngine;

public class Airplane : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float enginePower = 20f;
    [SerializeField] float liftBooter = 0.5f;
    [SerializeField] float drag = 0.001f;
    [SerializeField] float angularDrag = 0.001f;
    [SerializeField] float yawPower = 50f;
    [SerializeField] float pitchPower = 50f;
    [SerializeField] float rollPower = 30f;
        
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(transform.forward * enginePower);
        }
        //Lift Force
        Vector3 lift = Vector3.Project(rb.linearVelocity, transform.forward);
        rb.AddForce(transform.up * lift.magnitude * liftBooter);
        
        //Drag (Air Resistance)
        rb.linearDamping = rb.linearVelocity.magnitude * drag;
        rb.angularDamping = rb.linearVelocity.magnitude * angularDrag;
        
        //Rotation Controls
        float yaw = Input.GetAxis("Horizontal") * yawPower;
        float pitch = Input.GetAxis("Vertical") * pitchPower;
        float roll = Input.GetAxis("Roll") * rollPower;

        rb.AddTorque(transform.up * yaw);
        rb.AddTorque(transform.right * pitch);
        rb.AddTorque(transform.forward * roll);

    }
}
