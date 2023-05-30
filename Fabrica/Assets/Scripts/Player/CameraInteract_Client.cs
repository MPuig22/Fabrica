using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CameraInteract_Client : MonoBehaviourPunCallbacks
{
    public Camera playerCamera;

  
    public GameObject winClient_Panel;
    
    [Space] [Header("Contador Objeto Client")]
    //Contador de cada objeto
    public int countBrazos_Client;
    public int countPierna_Client;
    public int countPlato_Client;
    public int countCaja_Client;
    public int countPuerta_Client;
   
    public int countWin_Client;

    [Space] [Header("Objetos destruir Client")]
    //objectos para destruir
    public GameObject destruirBrazosRobot1_Client;
    public GameObject destruirBrazosRobot2_Client;
    public GameObject destruirPierna1_Client;
    public GameObject destruirPierna2_Client;
    public GameObject destruirPlato_Client;
    public GameObject destruirCaja_Client;
    public GameObject destruirPuerta_Client;
    
    [Space] [Header("Objetos final Client")]
    //objetos para activar
    public GameObject brazosFinal_Client;

    public GameObject piernaFinal_Client;
    public GameObject platoFinal_Client;
    public GameObject cajaFinal_Client;
    public GameObject puertaFinal_Client;

    [Space] [Header("Pickups Variables")] private GameObject pickup;
    public Transform targetPoint;

    [Space] [Header("Pickups bools Client")]
    //Bools para saber si se pueden agarrar los objetos
    public bool haveAPickup_Client;

    public bool haveAPickupPierna_Client;
    public bool haveAPickupPlato_Client;
    public bool haveAPickupCaja_Client;
    public bool haveAPickupPuerta_Client;

    public float rayCastRange;
    
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
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
        InstanciarObjetos();
        EsconderObjetos();
    }

    public void EsconderObjetos()
    {
        //Microones Final Client
        brazosFinal_Client.gameObject.SetActive(false);
        piernaFinal_Client.gameObject.SetActive(false);
        platoFinal_Client.gameObject.SetActive(false);
        cajaFinal_Client.gameObject.SetActive(false);
        puertaFinal_Client.gameObject.SetActive(false);
        
        //Paneles Win
       
        winClient_Panel.gameObject.SetActive(false);
    }

    public void InstanciarObjetos()
    {
        // Paneles Win
        
        winClient_Panel = GameObject.FindGameObjectWithTag("WinClient_Panel");
        
        //Objetos destruir Cliente
        destruirBrazosRobot1_Client = GameObject.FindGameObjectWithTag("DestruirBrazosRobot1_Client");
        destruirBrazosRobot2_Client = GameObject.FindGameObjectWithTag("DestruirBrazosRobot2_Client");
        destruirPierna1_Client = GameObject.FindGameObjectWithTag("DestruirPierna1_Client");
        destruirPierna2_Client = GameObject.FindGameObjectWithTag("DestruirPierna2_Client");
        destruirPlato_Client = GameObject.FindGameObjectWithTag("DestruirPlato_Client");
        destruirCaja_Client = GameObject.FindGameObjectWithTag("DestruirCaja_Client");
        destruirPuerta_Client = GameObject.FindGameObjectWithTag("DestruirPuerta_Client");
        
        //Objetos Final Client
        brazosFinal_Client = GameObject.FindGameObjectWithTag("BrazosFinal_Client");
        piernaFinal_Client = GameObject.FindGameObjectWithTag("PiernaFinal_Client");
        platoFinal_Client = GameObject.FindGameObjectWithTag("PlatoFinal_Client");
        cajaFinal_Client = GameObject.FindGameObjectWithTag("CajaFinal_Client");
        puertaFinal_Client = GameObject.FindGameObjectWithTag("PuertaFinal_Client");
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //Pulzar para poder recoger los brazos
        if (Input.GetKeyDown(KeyCode.E))
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
                        countWin_Client++;

                    }

                    if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit,
                            rayCastRange, pickupBrazo_1))
                    {
                        haveAPickup_Client = false;
                        countBrazos_Client++;
                        destruirBrazosRobot2_Client.gameObject.SetActive(false);
                        countWin_Client++;
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
                        countWin_Client++;
                    }

                    if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit,
                            rayCastRange, pickupPierna_1))
                    {
                        haveAPickupPierna_Client = false;
                        countPierna_Client++;
                        destruirPierna2_Client.gameObject.SetActive(false);
                        countWin_Client++;
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
                        countWin_Client++;
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
                        countWin_Client++;
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
                        destruirPuerta_Client.gameObject.SetActive(false);
                        countWin_Client++;
                    }
                }

        }
    }

    public void OnTriggerEnter(Collider other)
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
                
            }

            if (countCaja_Client >= 1)
            {
                cajaFinal_Client.gameObject.SetActive(true);
                haveAPickupCaja_Client = true;
                
            }

            if (countPlato_Client >= 1)
            {
                platoFinal_Client.gameObject.SetActive(true);
                haveAPickupPlato_Client = true;
                

            }

            if (countPuerta_Client >= 1)
            {
                puertaFinal_Client.gameObject.SetActive(true);
                haveAPickupPuerta_Client = true;
            }

            if (countWin_Client >= 7)
            {
                winClient_Panel.gameObject.SetActive(true);
                
            }
        }
    }
    
}
