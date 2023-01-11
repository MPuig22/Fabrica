using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraInteract : MonoBehaviour
{
    public Camera playerCamera;
    public int countBrazos;
    
    [Header("Pickups Variables")] 
    public bool haveAPickup;
    public float rayCastRange;
    public LayerMask brazoRobot;
    public LayerMask pantallaMicroones;
    public LayerMask CamesRobot;
    public LayerMask CaixaMicroones;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        { 
            if (!haveAPickup)
            {
                RaycastHit hit;
                if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, rayCastRange, brazoRobot))
                {
                    countBrazos++;
                }
            }
            else
            {
                haveAPickup = false;
            }
        }
    }
}
