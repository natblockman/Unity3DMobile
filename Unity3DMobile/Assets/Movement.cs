using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class Movement : MonoBehaviour
{
    public FixedJoystick move;
    private Rigidbody rb;
    private float cameraY;
    public float VelocitySpeed = 5f;
    private AnimatorController ac;
    public float JumpForce;
  

    public ControlButton btnButton;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ac = GetComponent<AnimatorController>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Walk();
        
        
    }
    void Walk()
    {
        Vector3 input = new Vector3(move.Direction.x, 0, move.Direction.y);
        Vector3 velocity = Quaternion.AngleAxis(cameraY ,Vector3.up) * input * VelocitySpeed;
        transform.rotation = Quaternion.AngleAxis(cameraY + Vector3.SignedAngle(Vector3.forward,input.normalized+Vector3.forward*0.001f,Vector3.up),Vector3.up);
        rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.z);
    }
    void Jump()
    {
        //stand on ground
        bool isGround = Physics.Raycast(transform.position + Vector3.up * 0.05f,Vector3.down,0.2f);
        //jump
        if (btnButton.pressed && isGround)
        {
            rb.velocity = new Vector3(rb.velocity.x, JumpForce, rb.velocity.z);
            ac.Jump();
        }
        else
        {
            if (rb.velocity.magnitude > 3f)
            {

                ac.Run();
            }
            else if (rb.velocity.magnitude > 0.5f)
            {

                ac.Walk();
            }
            else
            {
                ac.Idle();
            }
        }
    }
}
