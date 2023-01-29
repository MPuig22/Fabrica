using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class PlayerSetup : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject playerCamera;
    [SerializeField] private TextMeshProUGUI nombre_jugador;

    // Start is called before the first frame update
    void Start()
    {
        // Comrpovamos que el prefab que tiene el componente PhotonView esta siendo poseido por nosotros
        // Depeniendo si lo esta o no activamos el script del player controller y la camera del jugador
        if (photonView.IsMine)
        {
            transform.GetComponent<PlayerMovement>().enabled = true;
            playerCamera.GetComponent<Camera>().enabled = true;
        }
        else
        {
            transform.GetComponent<PlayerMovement>().enabled = false;
            playerCamera.GetComponent<Camera>().enabled = false;
        }

        Actualizar_Nombre();
    }

    private void Actualizar_Nombre()
    {
        nombre_jugador.text = photonView.Owner.NickName;
    }
}
