using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;


public class CameraInteract : MonoBehaviourPunCallbacks
{
    public Camera playerCamera;
    public AudioClip pickupSound;

    public GameObject winMaster_Panel;
    public GameObject winClient_Panel;

    [Space] [Header("Contador Objeto Master")]
    //Contador de cada objeto
    public int countBrazos;
    public int countPierna;
    public int countPlato;
    public int countCaja;
    public int countPuerta;
   
    public int countWin_Master;

    [Space] [Header("Contador Objeto Client")]
    //Contador de cada objeto
    public int countBrazos_Client;
    public int countPierna_Client;
    public int countPlato_Client;
    public int countCaja_Client;
    public int countPuerta_Client;
   
    public int countWin_Client;

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

    [Space] [Header("Iconos master")] 
    public GameObject cajaMicroondas_Master;
    public GameObject brazo1Microondas_Master;
    public GameObject brazo2Microondas_Master;
    public GameObject puertaMicroondas_Master;
    public GameObject pierna1Microondas_Master;
    public GameObject pierna2Microondas_Master;
    public GameObject platoMicroondas_Master;
    
    [Space] [Header("Iconos Client")]
    public GameObject cajaMicroondas_Client;
    public GameObject brazo1Microondas_Client;
    public GameObject brazo2Microondas_Client;
    public GameObject puertaMicroondas_Client;
    public GameObject pierna1Microondas_Client;
    public GameObject pierna2Microondas_Client;
    public GameObject platoMicroondas_Client;

    public GameObject timer;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
        InstanciarObjetos();
        EsconderObjetos();
        EncenderIconos_Master_Client();
    }

   
   


    public void EsconderObjetos()
    {
        //Microones Fianl Master
        brazosFinal.gameObject.SetActive(false);
        piernaFinal.gameObject.SetActive(false);
        platoFinal.gameObject.SetActive(false);
        cajaFinal.gameObject.SetActive(false);
        puertaFinal.gameObject.SetActive(false);
        
        //Microones Final Client
        brazosFinal_Client.gameObject.SetActive(false);
        piernaFinal_Client.gameObject.SetActive(false);
        platoFinal_Client.gameObject.SetActive(false);
        cajaFinal_Client.gameObject.SetActive(false);
        puertaFinal_Client.gameObject.SetActive(false);
        
        //Paneles Win
        winMaster_Panel.gameObject.SetActive(false);
        winClient_Panel.gameObject.SetActive(false);
        
        // Iconos master
        cajaMicroondas_Master.gameObject.SetActive(false);
        brazo1Microondas_Master.gameObject.SetActive(false);
        brazo2Microondas_Master.gameObject.SetActive(false);
        puertaMicroondas_Master.gameObject.SetActive(false);
        pierna1Microondas_Master.gameObject.SetActive(false);
        pierna2Microondas_Master.gameObject.SetActive(false);
        platoMicroondas_Master.gameObject.SetActive(false);
        
        // Iconos client
        cajaMicroondas_Client.gameObject.SetActive(false);
        brazo1Microondas_Client.gameObject.SetActive(false);
        brazo2Microondas_Client.gameObject.SetActive(false);
        puertaMicroondas_Client.gameObject.SetActive(false);
        pierna1Microondas_Client.gameObject.SetActive(false);
        pierna2Microondas_Client.gameObject.SetActive(false);
        platoMicroondas_Client.gameObject.SetActive(false);
        
    }

    public void EncenderIconos_Master_Client()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            // Iconos master
            cajaMicroondas_Master.gameObject.SetActive(true);
            brazo1Microondas_Master.gameObject.SetActive(true);
            brazo2Microondas_Master.gameObject.SetActive(true);
            puertaMicroondas_Master.gameObject.SetActive(true);
            pierna1Microondas_Master.gameObject.SetActive(true);
            pierna2Microondas_Master.gameObject.SetActive(true);
            platoMicroondas_Master.gameObject.SetActive(true);
        }
        else
        {
            // Iconos client
            cajaMicroondas_Client.gameObject.SetActive(true);
            brazo1Microondas_Client.gameObject.SetActive(true);
            brazo2Microondas_Client.gameObject.SetActive(true);
            puertaMicroondas_Client.gameObject.SetActive(true);
            pierna1Microondas_Client.gameObject.SetActive(true);
            pierna2Microondas_Client.gameObject.SetActive(true);
            platoMicroondas_Client.gameObject.SetActive(true);
        }
    }

    public void InstanciarObjetos()
    {
        // Iconos Master
        cajaMicroondas_Master = GameObject.FindGameObjectWithTag("CajaMicroondas_Master");
        brazo1Microondas_Master = GameObject.FindGameObjectWithTag("Brazo1Microondas_Master");
        brazo2Microondas_Master = GameObject.FindGameObjectWithTag("Brazo2Microondas_Master");
        puertaMicroondas_Master = GameObject.FindGameObjectWithTag("PuertaMicroondas_Master");
        pierna1Microondas_Master = GameObject.FindGameObjectWithTag("Pierna1Microondas_Master");
        pierna2Microondas_Master = GameObject.FindGameObjectWithTag("Pierna2Microondas_Master");
        platoMicroondas_Master = GameObject.FindGameObjectWithTag("PlatoMicroondas_Master");
        
        // Iconos Client
        cajaMicroondas_Client = GameObject.FindGameObjectWithTag("CajaMicroondas_Client");
        brazo1Microondas_Client = GameObject.FindGameObjectWithTag("Brazo1Microondas_Client");
        brazo2Microondas_Client = GameObject.FindGameObjectWithTag("Brazo2Microondas_Client");
        puertaMicroondas_Client = GameObject.FindGameObjectWithTag("PuertaMicroondas_Client");
        pierna1Microondas_Client = GameObject.FindGameObjectWithTag("Pierna1Microondas_Client");
        pierna2Microondas_Client = GameObject.FindGameObjectWithTag("Pierna2Microondas_Client");
        platoMicroondas_Client = GameObject.FindGameObjectWithTag("PlatoMicroondas_Client");
        
        // Paneles Win
        winMaster_Panel = GameObject.FindGameObjectWithTag("WinMaster_Panel");
        winClient_Panel = GameObject.FindGameObjectWithTag("WinClient_Panel");
        
        //Objetos destruir Master
        destruirBrazosRobot1 = GameObject.FindGameObjectWithTag("DestruirBrazosRobot1");
        destruirBrazosRobot2 = GameObject.FindGameObjectWithTag("DestruirBrazosRobot2");
        destruirPierna1 = GameObject.FindGameObjectWithTag("DestruirPierna1");
        destruirPierna2 = GameObject.FindGameObjectWithTag("DestruirPierna2");
        destruirPlato = GameObject.FindGameObjectWithTag("DestruirPlato");
        destruirCaja = GameObject.FindGameObjectWithTag("DestruirCaja");
        destruirPuerta = GameObject.FindGameObjectWithTag("DestruirPuerta");
        
        //Objetos destruir Cliente
        destruirBrazosRobot1_Client = GameObject.FindGameObjectWithTag("DestruirBrazosRobot1_Client");
        destruirBrazosRobot2_Client = GameObject.FindGameObjectWithTag("DestruirBrazosRobot2_Client");
        destruirPierna1_Client = GameObject.FindGameObjectWithTag("DestruirPierna1_Client");
        destruirPierna2_Client = GameObject.FindGameObjectWithTag("DestruirPierna2_Client");
        destruirPlato_Client = GameObject.FindGameObjectWithTag("DestruirPlato_Client");
        destruirCaja_Client = GameObject.FindGameObjectWithTag("DestruirCaja_Client");
        destruirPuerta_Client = GameObject.FindGameObjectWithTag("DestruirPuerta_Client");
        
        //Objetos Final Master
        brazosFinal = GameObject.FindGameObjectWithTag("BrazosFinal");
        piernaFinal = GameObject.FindGameObjectWithTag("PiernaFinal");
        platoFinal = GameObject.FindGameObjectWithTag("PlatoFinal");
        cajaFinal = GameObject.FindGameObjectWithTag("CajaFinal");
        puertaFinal = GameObject.FindGameObjectWithTag("PuertaFinal");
        
        //Objetos Final Client
        brazosFinal_Client = GameObject.FindGameObjectWithTag("BrazosFinal_Client");
        piernaFinal_Client = GameObject.FindGameObjectWithTag("PiernaFinal_Client");
        platoFinal_Client = GameObject.FindGameObjectWithTag("PlatoFinal_Client");
        cajaFinal_Client = GameObject.FindGameObjectWithTag("CajaFinal_Client");
        puertaFinal_Client = GameObject.FindGameObjectWithTag("PuertaFinal_Client");
        
        timer = GameObject.FindGameObjectWithTag("Timer");
        
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
                        PhotonNetwork.Destroy(destruirBrazosRobot1);
                        countWin_Master++;
                        brazo1Microondas_Master.SetActive(false);
                        AudioSource.PlayClipAtPoint(pickupSound, transform.position);



                    }

                    if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit,
                            rayCastRange, pickupMask))
                    {
                        haveAPickup = false;
                        countBrazos++;
                        PhotonNetwork.Destroy(destruirBrazosRobot2);
                        countWin_Master++;
                        brazo2Microondas_Master.SetActive(false);
                        AudioSource.PlayClipAtPoint(pickupSound, transform.position);
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
                        PhotonNetwork.Destroy(destruirPierna1);
                        countWin_Master++;
                        pierna1Microondas_Master.SetActive(false);
                        AudioSource.PlayClipAtPoint(pickupSound, transform.position);
                    }

                    if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit,
                            rayCastRange, pickupPierna))
                    {
                        haveAPickupPierna = false;
                        countPierna++;
                        PhotonNetwork.Destroy(destruirPierna2);
                        countWin_Master++;
                        pierna2Microondas_Master.SetActive(false);
                        AudioSource.PlayClipAtPoint(pickupSound, transform.position);
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
                        PhotonNetwork.Destroy(destruirCaja);
                        countWin_Master++;
                        cajaMicroondas_Master.SetActive(false);
                        AudioSource.PlayClipAtPoint(pickupSound, transform.position);
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
                        PhotonNetwork.Destroy(destruirPlato);
                        countWin_Master++;
                        platoMicroondas_Master.SetActive(false);
                        AudioSource.PlayClipAtPoint(pickupSound, transform.position);
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
                       PhotonNetwork.Destroy(destruirPuerta);
                        countWin_Master++;
                        puertaMicroondas_Master.SetActive(false);
                        AudioSource.PlayClipAtPoint(pickupSound, transform.position);
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
                        PhotonNetwork.Destroy(destruirBrazosRobot1_Client);
                        countWin_Client++;
                        brazo1Microondas_Client.SetActive(false);
                        AudioSource.PlayClipAtPoint(pickupSound, transform.position);

                    }

                    if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit,
                            rayCastRange, pickupBrazo_1))
                    {
                        haveAPickup_Client = false;
                        countBrazos_Client++;
                        PhotonNetwork.Destroy(destruirBrazosRobot2_Client);
                        countWin_Client++;
                        brazo2Microondas_Client.SetActive(false);
                        AudioSource.PlayClipAtPoint(pickupSound, transform.position);
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
                        PhotonNetwork.Destroy(destruirPierna1_Client);
                        countWin_Client++;
                        pierna1Microondas_Client.gameObject.SetActive(false);
                        AudioSource.PlayClipAtPoint(pickupSound, transform.position);
                        
                    }

                    if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit,
                            rayCastRange, pickupPierna_1))
                    {
                        haveAPickupPierna_Client = false;
                        countPierna_Client++;
                        PhotonNetwork.Destroy(destruirPierna2_Client);
                        countWin_Client++;
                        pierna2Microondas_Client.gameObject.SetActive(false);
                        AudioSource.PlayClipAtPoint(pickupSound, transform.position);
                        
                        
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
                        PhotonNetwork.Destroy(destruirCaja_Client);
                        countWin_Client++;
                        cajaMicroondas_Client.gameObject.SetActive(false);
                        AudioSource.PlayClipAtPoint(pickupSound, transform.position);
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
                        PhotonNetwork.Destroy(destruirPlato_Client);
                        countWin_Client++;
                        platoMicroondas_Client.gameObject.SetActive(false);
                        AudioSource.PlayClipAtPoint(pickupSound, transform.position);
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
                        countPuerta_Client++;
                        PhotonNetwork.Destroy(destruirPuerta_Client);
                        countWin_Client++;
                        puertaMicroondas_Client.gameObject.SetActive(false);
                        AudioSource.PlayClipAtPoint(pickupSound, transform.position);
                        
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
                if (countBrazos >= 2)
                {
                    brazosFinal.gameObject.SetActive(true);
                    haveAPickup = true;
                    //destruirPuerta.gameObject.SetActive(true);
                    
                }

                if (countPierna >= 2)
                {
                    piernaFinal.gameObject.SetActive(true);
                    haveAPickupPierna = true;
                    // destruirCaja.gameObject.SetActive(true);
                    
                }

                if (countCaja >= 1)
                {
                    cajaFinal.gameObject.SetActive(true);
                    haveAPickupCaja = true;
                    //destruirPlato.gameObject.SetActive(true);
                    
                }

                if (countPlato >= 1)
                {
                    platoFinal.gameObject.SetActive(true);
                    haveAPickupPlato = true;
                    // destruirBrazosRobot2.gameObject.SetActive(true);
                    // destruirBrazosRobot1.gameObject.SetActive(true);
                    

                }

                if (countPuerta >= 1)
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
                if (countBrazos_Client >= 2)
                {
                    brazosFinal_Client.gameObject.SetActive(true);
                    haveAPickup_Client = true;
                }

                if (countPierna_Client >= 2)
                {
                    piernaFinal_Client.gameObject.SetActive(true);
                    haveAPickupPierna_Client = true;
                    // destruirCaja.gameObject.SetActive(true);
                }

                if (countCaja_Client >= 1)
                {
                   cajaFinal_Client.gameObject.SetActive(true);
                    haveAPickupCaja_Client = true;
                    //destruirPlato.gameObject.SetActive(true);
                }

                if (countPlato_Client >= 1)
                {
                    platoFinal_Client.gameObject.SetActive(true);
                    haveAPickupPlato_Client = true;
                    // destruirBrazosRobot2.gameObject.SetActive(true);
                    // destruirBrazosRobot1.gameObject.SetActive(true);

                }

                if (countPuerta_Client >= 1)
                {
                    puertaFinal_Client.gameObject.SetActive(true);
                    haveAPickupPuerta_Client = true;
                }

                
            }
        }

        if (other.gameObject.CompareTag("PlataformaClient"))
        {
            if (countWin_Client >= 7)
            {
                winClient_Panel.gameObject.SetActive(true);
                Cursor.visible = true;
                PhotonNetwork.Destroy(timer);
                Cursor.lockState = CursorLockMode.None;

            }
        }

        if (other.gameObject.CompareTag("PlataformaMaster"))
        {
            if (countWin_Master >= 7)
            {
                winMaster_Panel.gameObject.SetActive(true);
                Cursor.visible = true;
                PhotonNetwork.Destroy(timer);
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }

}    