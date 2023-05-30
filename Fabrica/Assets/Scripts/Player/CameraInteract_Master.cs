using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CameraInteract_Master : MonoBehaviourPunCallbacks
{
    
    public Camera playerCamera;

    public GameObject winMaster_Panel;
   

    [Space] [Header("Contador Objeto Master")]
    //Contador de cada objeto
    public int countBrazos;
    public int countPierna;
    public int countPlato;
    public int countCaja;
    public int countPuerta;
   
    public int countWin_Master;
    
    [Space] [Header("Objetos destruir Master")]
    //objectos para destruir
    public GameObject destruirBrazosRobot1;
    public GameObject destruirBrazosRobot2;
    public GameObject destruirPierna1;
    public GameObject destruirPierna2;
    public GameObject destruirPlato;
    public GameObject destruirCaja;
    public GameObject destruirPuerta;
    
    [Space] [Header("Objetos final Master")]
    //objetos para activar
    public GameObject brazosFinal;

    public GameObject piernaFinal;
    public GameObject platoFinal;
    public GameObject cajaFinal;
    public GameObject puertaFinal;
    
    [Space] [Header("Pickups Variables")] private GameObject pickup;
    public Transform targetPoint;

    [Space] [Header("Pickups bools Master")]
    //Bools para saber si se pueden agarrar los objetos
    public bool haveAPickup;
    public bool haveAPickupPierna;
    public bool haveAPickupPlato;
    public bool haveAPickupCaja;
    public bool haveAPickupPuerta;
    
    public float rayCastRange;

    [Space] [Header("LayerMascs Master")]
    // layers para saber que objeto es que (Master)
    public LayerMask pickupMask;

    public LayerMask pickupPierna;
    public LayerMask puertaMicroones;
    public LayerMask CaixaMicroones;
    public LayerMask pickupPlato;

    
    
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
        //Microones Fianl Master
        brazosFinal.gameObject.SetActive(false);
        piernaFinal.gameObject.SetActive(false);
        platoFinal.gameObject.SetActive(false);
        cajaFinal.gameObject.SetActive(false);
        puertaFinal.gameObject.SetActive(false);

        //Paneles Win
        winMaster_Panel.gameObject.SetActive(false);
       
        
    }

    public void InstanciarObjetos()
    {
        // Paneles Win
        winMaster_Panel = GameObject.FindGameObjectWithTag("WinMaster_Panel");
       
        
        //Objetos destruir Master
        destruirBrazosRobot1 = GameObject.FindGameObjectWithTag("DestruirBrazosRobot1");
        destruirBrazosRobot2 = GameObject.FindGameObjectWithTag("DestruirBrazosRobot2");
        destruirPierna1 = GameObject.FindGameObjectWithTag("DestruirPierna1");
        destruirPierna2 = GameObject.FindGameObjectWithTag("DestruirPierna2");
        destruirPlato = GameObject.FindGameObjectWithTag("DestruirPlato");
        destruirCaja = GameObject.FindGameObjectWithTag("DestruirCaja");
        destruirPuerta = GameObject.FindGameObjectWithTag("DestruirPuerta");
        
        //Objetos Final Master
        brazosFinal = GameObject.FindGameObjectWithTag("BrazosFinal");
        piernaFinal = GameObject.FindGameObjectWithTag("PiernaFinal");
        platoFinal = GameObject.FindGameObjectWithTag("PlatoFinal");
        cajaFinal = GameObject.FindGameObjectWithTag("CajaFinal");
        puertaFinal = GameObject.FindGameObjectWithTag("PuertaFinal");
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

                    if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit,
                            rayCastRange, pickupMask))
                    {
                        haveAPickup = false;
                        countBrazos++;
                        destruirBrazosRobot1.gameObject.SetActive(false);
                        countWin_Master++;

                    }

                    if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit,
                            rayCastRange, pickupMask))
                    {
                        haveAPickup = false;
                        countBrazos++;
                        destruirBrazosRobot2.gameObject.SetActive(false);
                        countWin_Master++;
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
                        countWin_Master++;
                    }

                    if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit,
                            rayCastRange, pickupPierna))
                    {
                        haveAPickupPierna = false;
                        countPierna++;
                        destruirPierna2.gameObject.SetActive(false);
                        countWin_Master++;
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
                        countWin_Master++;
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
                        countWin_Master++;
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
                        countWin_Master++;
                }
                    
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlataformaMaster"))
        {
            if (countBrazos >= 2)
            {
                brazosFinal.gameObject.SetActive(true);
                haveAPickup = true;
               
                    
            }

            if (countPierna >= 2)
            {
                piernaFinal.gameObject.SetActive(true);
                haveAPickupPierna = true;
               
                    
            }

            if (countCaja >= 1)
            {
                cajaFinal.gameObject.SetActive(true);
                haveAPickupCaja = true;
               
                    
            }

            if (countPlato >= 1)
            {
                platoFinal.gameObject.SetActive(true);
                haveAPickupPlato = true;
                
                    

            }

            if (countPuerta >= 1)
            {
                puertaFinal.gameObject.SetActive(true);
                haveAPickupPuerta = true;
                    
            }

            if (countWin_Master >= 7)
            {
                winMaster_Panel.gameObject.SetActive(true);
                
            }

        }
    }
}
