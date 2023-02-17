using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using Photon.Pun;

public class CameraInteract : MonoBehaviourPunCallbacks
{
    public Camera playerCamera;

    [Space] [Header("Contador Objeto Master")]
    //Contador de cada objeto
    public int countBrazos;

    public int countPierna;
    public int countPlato;
    public int countCaja;
    public int countPuerta;

    [Space] [Header("Contador Objeto Client")]
    //Contador de cada objeto
    public int countBrazos_Client;

    public int countPierna_Client;
    public int countPlato_Client;
    public int countCaja_Client;
    public int countPuerta_Client;

    [Space] [Header("Objetos destruir Master")]
    //objectos para destruir
    public GameObject destruirBrazosRobot1;

    public GameObject destruirBrazosRobot2;
    public GameObject destruirPierna1;
    public GameObject destruirPierna2;
    public GameObject destruirPlato;
    public GameObject destruirCaja;
    public GameObject destruirPuerta;

    [Space] [Header("Objetos destruir Client")]
    //objectos para destruir
    public GameObject destruirBrazosRobot1_Client;

    public GameObject destruirBrazosRobot2_Client;
    public GameObject destruirPierna1_Client;
    public GameObject destruirPierna2_Client;
    public GameObject destruirPlato_Client;
    public GameObject destruirCaja_Client;
    public GameObject destruirPuerta_Client;

    [Space] [Header("Objetos final Master")]
    //objetos para activar
    public GameObject brazosFinal;

    public GameObject piernaFinal;
    public GameObject platoFinal;
    public GameObject cajaFinal;
    public GameObject puertaFinal;

    [Space] [Header("Objetos final Client")]
    //objetos para activar
    public GameObject brazosFinal_Client;

    public GameObject piernaFinal_Client;
    public GameObject platoFinal_Client;
    public GameObject cajaFinal_Client;
    public GameObject puertaFinal_Client;

    [Space] [Header("Pickups Variables")] private GameObject pickup;
    public Transform targetPoint;

    [Space] [Header("Pickups bools Master")]
    //Bools para saber si se pueden agarrar los objetos
    public bool haveAPickup;

    public bool haveAPickupPierna;
    public bool haveAPickupPlato;
    public bool haveAPickupCaja;
    public bool haveAPickupPuerta;

    [Space] [Header("Pickups bools Client")]
    //Bools para saber si se pueden agarrar los objetos
    public bool haveAPickup_Client;

    public bool haveAPickupPierna_Client;
    public bool haveAPickupPlato_Client;
    public bool haveAPickupCaja_Client;
    public bool haveAPickupPuerta_Client;

    public float rayCastRange;

    [Space] [Header("LayerMascs Master")]
    // layers para saber que objeto es que (Master)
    public LayerMask pickupMask;

    public LayerMask pickupPierna;
    public LayerMask puertaMicroones;
    public LayerMask CaixaMicroones;
    public LayerMask pickupPlato;


    [Space] [Header("LayerMascs Client")]
    // layers para saber que objeto es que (Client)
    public LayerMask pickupBrazo_1;

    public LayerMask pickupPierna_1;
    public LayerMask puertaMicroones_1;
    public LayerMask CaixaMicroones_1;
    public LayerMask pickupPlato_1;



    // Start is called before the first frame update
    void Start()
    {
        InstanciarObjetos();
    }

    public void InstanciarObjetos()
    {
        // fer aixo amb tots els objectes
        destruirBrazosRobot1 = GameObject.FindGameObjectWithTag("DestruirBrazosRobot1");
    }
    
    // Update is called once per frame
    void Update()
    {

        //Pulzar para poder recoger los brazos
        if (Input.GetKeyDown(KeyCode.E))
        {

            if (PhotonNetwork.IsMasterClient)
            {

                if (!haveAPickup)
                {

                    RaycastHit hit;

                    if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit,
                            rayCastRange, pickupMask))
                    {
                        haveAPickup = false;
                        countBrazos++;
                        destruirBrazosRobot1.gameObject.SetActive(false);

                    }

                    if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit,
                            rayCastRange, pickupMask))
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

                    if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit,
                            rayCastRange, pickupPierna))
                    {
                        haveAPickupPierna = false;
                        countPierna++;
                        destruirPierna1.gameObject.SetActive(false);
                    }

                    if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit,
                            rayCastRange, pickupPierna))
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

                    if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit,
                            rayCastRange, CaixaMicroones))
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

                    if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit,
                            rayCastRange, pickupPlato))
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

                    if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit,
                            rayCastRange, puertaMicroones))
                    {
                        haveAPickupPuerta = false;
                        countPuerta++;
                        destruirPuerta.gameObject.SetActive(false);
                    }
                }


            }
            else
            {
                if (!haveAPickup_Client)
                {

                    RaycastHit hit;

                    if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit,
                            rayCastRange, pickupBrazo_1))
                    {
                        haveAPickup_Client = false;
                        countBrazos_Client++;
                        destruirBrazosRobot1_Client.gameObject.SetActive(false);

                    }

                    if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit,
                            rayCastRange, pickupBrazo_1))
                    {
                        haveAPickup_Client = false;
                        countBrazos_Client++;
                        destruirBrazosRobot2_Client.gameObject.SetActive(false);
                    }

                }

                // pulsar para poder recoger las piernas
                if (!haveAPickupPierna_Client)
                {

                    RaycastHit hit;

                    if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit,
                            rayCastRange, pickupPierna_1))
                    {
                        haveAPickupPierna_Client = false;
                        countPierna_Client++;
                        destruirPierna1_Client.gameObject.SetActive(false);
                    }

                    if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit,
                            rayCastRange, pickupPierna_1))
                    {
                        haveAPickupPierna_Client = false;
                        countPierna_Client++;
                        destruirPierna2_Client.gameObject.SetActive(false);
                    }
                }

                // pulsar para poder recoger la caja
                if (!haveAPickupCaja_Client)
                {

                    RaycastHit hit;

                    if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit,
                            rayCastRange, CaixaMicroones_1))
                    {
                        haveAPickupCaja_Client = false;
                        countCaja_Client++;
                        destruirCaja_Client.gameObject.SetActive(false);
                    }
                }

                // pulsar para poder recoger la plato
                if (!haveAPickupPlato_Client)
                {

                    RaycastHit hit;

                    if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit,
                            rayCastRange, pickupPlato_1))
                    {
                        haveAPickupPlato_Client = false;
                        countPlato_Client++;
                        destruirPlato_Client.gameObject.SetActive(false);
                    }
                }

                // pulsar para poder recoger la puerta
                if (!haveAPickupPuerta_Client)
                {

                    RaycastHit hit;

                    if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit,
                            rayCastRange, puertaMicroones_1))
                    {
                        haveAPickupPuerta_Client = false;
                        countPlato_Client++;
                        destruirPuerta_Client.gameObject.SetActive(false);
                    }
                }
            }


        }


    }

    public void OnTriggerEnter(Collider other)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            if (other.gameObject.CompareTag("PlataformaMaster"))
            {
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
        else
        {
            if (other.gameObject.CompareTag("PlataformaClient"))
            {
                if (countBrazos_Client == 2)
                {
                    brazosFinal_Client.gameObject.SetActive(true);
                    haveAPickup_Client = true;
                }

                if (countPierna_Client == 2)
                {
                    piernaFinal_Client.gameObject.SetActive(true);
                    haveAPickupPierna_Client = true;
                    // destruirCaja.gameObject.SetActive(true);
                }

                if (countCaja_Client == 1)
                {
                    cajaFinal_Client.gameObject.SetActive(true);
                    haveAPickupCaja_Client = true;
                    //destruirPlato.gameObject.SetActive(true);
                }

                if (countPlato_Client == 1)
                {
                    platoFinal_Client.gameObject.SetActive(true);
                    haveAPickupPlato_Client = true;
                    // destruirBrazosRobot2.gameObject.SetActive(true);
                    // destruirBrazosRobot1.gameObject.SetActive(true);

                }

                if (countPuerta_Client == 1)
                {
                    puertaFinal_Client.gameObject.SetActive(true);
                    haveAPickupPuerta_Client = true;
                }
            }
        }

    }
}    