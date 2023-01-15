using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraInteract : MonoBehaviour
{
    public Camera playerCamera;
    public int countBrazos;
    //objectos para destruir
    public GameObject destruirBrazosRobot1;
    public GameObject destruirBrazosRobot2;

    //objetos para activar
    public GameObject brazosFinal;


    [Header("Pickups Variables")]
    private GameObject pickup;
    public Transform targetPoint;
    public bool haveAPickup;
    public float rayCastRange;
    public LayerMask pickupMask;
    public LayerMask pickupMask1;

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
        if(countBrazos == 2)
        {
            brazosFinal.gameObject.SetActive(true);
        }



        //Pulzar para poder recoger los brazos
        if (Input.GetKeyDown(KeyCode.E))
        {

            if (!haveAPickup)
            {

                RaycastHit hit;


                if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, rayCastRange, pickupMask))
                {
                    haveAPickup = false;
                    countBrazos++;
                    Destroy(destruirBrazosRobot1);

                }
            } 
        }

        if (Input.GetKeyDown(KeyCode.E))
        {

            if (!haveAPickup)
            {

                RaycastHit hit;


                if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, rayCastRange, pickupMask1))
                {
                    haveAPickup = false;
                    countBrazos++;
                    Destroy(destruirBrazosRobot2);

                }
            }
        }
    }
}
