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
                    destruirBrazosRobot1.gameObject.SetActive(false);

                }

                if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, rayCastRange, pickupMask1))
                {
                    haveAPickup = false;
                    countBrazos++;
                    destruirBrazosRobot2.gameObject.SetActive(false);
                }

            }

            // pulsar para poder recoger las piernas
            if (!haveAPickupPierna)
            {

                RaycastHit hit;

                if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, rayCastRange, pickupPierna))
                {
                    haveAPickupPierna = false;
                    countPierna++;
                    destruirPierna1.gameObject.SetActive(false);
                }

                if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, rayCastRange, pickupPierna1))
                {
                    haveAPickupPierna = false;
                    countPierna++;
                    destruirPierna2.gameObject.SetActive(false);
                }
            }

            // pulsar para poder recoger la caja
            if (!haveAPickupCaja)
            {

                RaycastHit hit;

                if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, rayCastRange, CaixaMicroones))
                {
                    haveAPickupCaja = false;
                    countCaja++;
                    destruirCaja.gameObject.SetActive(false);
                }
            }

            // pulsar para poder recoger la plato
            if (!haveAPickupPlato)
            {

                RaycastHit hit;

                if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, rayCastRange, pickupPlato))
                {
                    haveAPickupPlato = false;
                    countPlato++;
                    destruirPlato.gameObject.SetActive(false);
                }
            }

            // pulsar para poder recoger la puerta
            if (!haveAPickupPuerta)
            {

                RaycastHit hit;

                if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, rayCastRange, puertaMicroones))
                {
                    haveAPickupPuerta = false;
                    countPuerta++;
                    destruirPuerta.gameObject.SetActive(false);
                }
            }
        }

        if (countBrazos == 2)
        {
            brazosFinal.gameObject.SetActive(true);
            haveAPickup = true;
            //destruirPuerta.gameObject.SetActive(true);
        }

        if (countPierna == 2)
        {
            piernaFinal.gameObject.SetActive(true);
            haveAPickupPierna = true;
           // destruirCaja.gameObject.SetActive(true);
        }

        if (countCaja == 1)
        {
            cajaFinal.gameObject.SetActive(true);
            haveAPickupCaja = true;
            //destruirPlato.gameObject.SetActive(true);
        }

        if (countPlato == 1)
        {
            platoFinal.gameObject.SetActive(true);
            haveAPickupPlato = true;
           // destruirBrazosRobot2.gameObject.SetActive(true);
           // destruirBrazosRobot1.gameObject.SetActive(true);

        }

        if (countPuerta == 1)
        {
            puertaFinal.gameObject.SetActive(true);
            haveAPickupPuerta = true;
        }

    }
}