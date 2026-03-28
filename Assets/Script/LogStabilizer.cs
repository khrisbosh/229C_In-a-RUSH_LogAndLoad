using UnityEngine;

public class LogStabilizer : MonoBehaviour
{
    public Transform truck;
    public float stickForce = 50f;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (truck == null) return;

        // ดึงไม้เข้าหารถเล็กน้อย
        Vector3 dir = (truck.position - transform.position).normalized;
        rb.AddForce(dir * stickForce);

        // ลดความเร็วหมุน
        rb.angularVelocity *= 0.95f;
    }
}