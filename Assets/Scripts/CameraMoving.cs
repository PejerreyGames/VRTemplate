using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CameraMoving : MonoBehaviour
{
    [SerializeField] public GameObject camera;
    [SerializeField] public List<GameObject> fondos;
    private int posact;
    private float lastSwapTime;
    public float swapCooldown = 0.3f;

    private void Start()
    {
        camera.transform.position = fondos[0].transform.position;
        posact = 0;
        lastSwapTime = -swapCooldown; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastSwapTime >= swapCooldown)
        {
           if (Input.GetKey(KeyCode.E))
           {
               if (fondos.Count-1 >= posact+1)
               {
                   Debug.Log((fondos.Count));
                   Debug.Log((posact));
                   camera.transform.position = fondos[posact+1].transform.position;
                    
                   fondos[posact+1].GetComponentInChildren<VideoPlayer>().frame = 0;
                   posact++;
                   lastSwapTime = Time.time;
               }
           }  
        }
         
    }
}
