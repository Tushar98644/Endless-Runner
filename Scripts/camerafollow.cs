using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    [Header("Follow")]
    public Transform lookat;
    private Vector3 startoffset;
    private Vector3 movevector;


    [Header("StartAnimation")]
    public float transition = 0f;
    public float animationduration = 3f;
    private Vector3 animationoffset = new Vector3(0, 5, 5);


    void Start()
    {
        startoffset = transform.position - lookat.position;
    }

   
    void Update()
    {
        movevector = lookat.position + startoffset;

        movevector.x = 0;
        movevector.y = Mathf.Clamp(movevector.y, 3, 6);


        if(transition>1f)
        {
            transform.position = movevector;
            // position of player =position of camera
        }

        else
        {
            transform.position = Vector3.Lerp(movevector + animationoffset, movevector, transition);
            transition += Time.deltaTime * 1 / animationduration;
            transform.LookAt(lookat.position + Vector3.up);
        }



    }
}
