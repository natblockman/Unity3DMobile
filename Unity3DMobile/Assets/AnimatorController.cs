using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    public Animator anim;
    public Movement movement;
   
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        movement = GetComponent<Movement>();
      
    }

    public void Idle()
    {
        anim.SetFloat("Speed",0f);
    }
    public void Walk()
    {
        anim.SetFloat("Speed", 0.5f);
    }
    public void Run()
    {
        anim.SetFloat("Speed", 1f);
    }

    public void Jump()
    {
        anim.SetTrigger("Jump");
    }
    public void Attack()
    {

    }
    public void TakeDamege()
    {

    }
}
