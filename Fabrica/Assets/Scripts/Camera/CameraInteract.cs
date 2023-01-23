using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraInteract : MonoBehaviour
{
    public Camera playerCamera;

    //Contador de cada objeto
    public int countBrazos;
    public int countPierna;
    public int countPlato;
    public int countCaja;
    public int countPuerta;

    //objectos para destruir
    public GameObject destruirBrazosRobot1;
    public GameObject destruirBrazosRobot2;
    public GameObject destruirPierna1;
    public GameObject destruirPierna2;
    public GameObject destruirPlato;
    public GameObject destruirCaja;
    public GameObject destruirPuerta;

    //objetos para activar
    public GameObject brazosFinal;
    public GameObject piernaFinal;
    public GameObject platoFinal;
    public GameObject cajaFinal;
    public GameObject puertaFinal;

    [Header("Pickups Variables")]
    private GameObject pickup;
    public Transform targetPoint;

    //Bools para saber si se pueden agarrar los objetos
    public bool haveAPickup;
    public bool haveAPickupPierna;
    public bool haveAPickupPlato;
    public bool haveAPickupCaja;
    public bool haveAPickupPuerta;

    public float rayCastRange;

    // layers para saber que objeto es que
    public LayerMask pickupMask;
    public LayerMask pickupMask1;
    public LayerMask pickupPierna;
    public LayerMask pickupPierna1;
    public LayerMask puertaMicroones;
    public LayerMask CaixaMicroones;
    public LayerMask pickupPlato;


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
            haveAPickup = true;
        }

        if(countPierna == 2)
        {
            piernaFinal.gameObject.SetActive(true);
            haveAPickupPierna = true;
            destruirCaja.gameObject.SetActive(true);
        }

        if(countCaja == 1)
        {
            cajaFinal.gameObject.SetActive(true);
            haveAPickupCaja = true;
            destruirPlato.gameObject.SetActive(true);       
        }

        if(countPlato == 1)
        {
            platoFinal.gameObject.SetActive(true);
            haveAPickupPlato = true;
            destruirBrazosRobot2.gameObject.SetActive(true);
            destruirBrazosRobot1.gameObject.SetActive(true);

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

                if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, rayCastRange, pickupMask1))
                {
                    haveAPickup = false;
                    countBrazos++;
                    Destroy(destruirBrazosRobot2);
                }
            } 
        }


        // pulsar para poder recoger las piernas
        if (Input.GetKeyDown(KeyCode.E))
        {

            if (!haveAPickupPierna)
            {

                RaycastHit hit;


                if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, rayCastRange, pickupPierna))
                {
                    haveAPickupPierna = false;
                    countPierna++;
                    Destroy(destruirPierna1);

                }

                if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, rayCastRange, pickupPierna1))
                {
                    haveAPickupPierna = false;
                    countPierna++;
                    Destroy(destruirPierna2);

                }
            } 
        }

        // pulsar para poder recoger la caja
        if (Input.GetKeyDown(KeyCode.E))
        {

            if (!haveAPickupCaja)
            {

                RaycastHit hit;


                if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, rayCastRange, CaixaMicroones))
                {
                    haveAPickupCaja = false;
                    countCaja++;
                    Destroy(destruirCaja);

                }        
            }
        }

        // pulsar para poder recoger la plato
        if (Input.GetKeyDown(KeyCode.E))
        {

            if (!haveAPickupPlato)
            {

                RaycastHit hit;


                if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, rayCastRange, pickupPlato))
                {
                    haveAPickupPlato = false;
                    countPlato++;
                    Destroy(destruirPlato);

                }
            }
        }

    }


    


}
