using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Item_info_UsuarioConectado : MonoBehaviour
{
    public string nickname_usuario;

    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = nickname_usuario;
    }
}
