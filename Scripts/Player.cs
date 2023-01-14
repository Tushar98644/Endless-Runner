using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("cc")]
    public CharacterController controller;
    

    [Header("speed and gravity")]
    public float speed=5f;
    public Vector3 movevector;
    public float verticalvelocity = 0f;
    public float gravity = 12f;
    public float animationduration = 3f;
    private float starttime=0f;
   

    [Header("Player Death")]
    private bool isdead = false;
    public GameObject DeathMenu;

    void Start()
    {
        DeathMenu.SetActive(false);
        starttime = Time.time;
    }

    
    void Update()

    {
        if (isdead)
            return;

        if(Time.time-starttime<animationduration)
        {
            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;

        }

        movevector = Vector3.zero;

        if(controller.isGrounded)
        {
            verticalvelocity = -0.5f;
        }
        else
        {
            verticalvelocity -= gravity*Time.deltaTime;
        }


        //x-left or right
        movevector.x = Input.GetAxisRaw("Horizontal")*speed;

        //y-up and down
        movevector.y = verticalvelocity;


        //z-backword or forward
        movevector.z = speed;



        controller.Move(movevector* Time.deltaTime);
    }

    public void Speedincrement(int modify )
    {
        speed = 5 + 2*modify;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
       if(hit.point.z>transform.position.z + (controller.radius/2) && hit.gameObject.tag=="Enemy"  )
        {
            Death();
        }
    }

    public void Death()
    {
        isdead = true;
        Debug.Log("dead");
        GetComponent<PlayerScore>().OnDeath();
        DeathMenu.SetActive(true);
    }
}
