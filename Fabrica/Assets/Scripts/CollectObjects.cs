using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class CollectObjects : MonoBehaviour
{
    //Lista objetos para recoger
    public Text brazos_txt;
    public int countBrazos;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
            
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("tuerca"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                brazos_txt.gameObject.SetActive(false);
                Destroy(other.gameObject);
                countBrazos++;
            }
        }
    }
}
