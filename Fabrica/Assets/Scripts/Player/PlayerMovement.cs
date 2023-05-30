using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] private float speed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float sensibilityMouse;
    [SerializeField] private Transform playerCamera;

    private Vector2 inputMov;
    
    private Rigidbody _rigidbody;
    

    private Vector3 movement;
    private bool jumping;
    public float jumpForce;
    private bool isRunning;

    public AudioSource pasos;
    public AudioSource salto;

    private bool h_activo;
    private bool v_activo;

    

   
    // Start is called before the first frame update
    void Start()
    {
        // Recuperamos el componente Rigidbody del player para poder trabajar con el
        _rigidbody = GetComponent<Rigidbody>();

        

        

    }

    // Update is called once per frame
    void Update()
    {
        // Leemos los inputs para el desplazamiento del jugador

          
         inputMov.x = Input.GetAxis("Horizontal");
        inputMov.y = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Horizontal"))
        {
            if (v_activo == false)
            {
                h_activo = true;
                pasos.Play();  
            }
           
        }
        if (Input.GetButtonDown("Vertical"))
        {
            if (h_activo == false)
            {
                v_activo = true;
                pasos.Play();
            }
            
        }
        
        if (Input.GetButtonUp("Horizontal"))
        {
            h_activo = true;
            if (v_activo == false)
            {
                pasos.Pause();
            }
            
        }
        if (Input.GetButtonUp("Vertical"))
        {
            v_activo = true;
            if (h_activo == false)
            {
                pasos.Pause();
            }
            
        }

       
       
       
       
        // logica de salto
        if (Input.GetKeyDown(KeyCode.Space) && jumping == false)
        {
            _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumping = true;
            salto.Play();
        }

        //Logica correr
       if (Input.GetKey(KeyCode.LeftShift))
        {
           isRunning = true;
           
        }
        else
        {
            isRunning = false;
        }

        

    }

    private void FixedUpdate()
    {
        if (isRunning)
        {
            _rigidbody.velocity = transform.forward * runSpeed * inputMov.y  // Movimiento hacia adelante y atr�s del PJ
                                  + transform.right * runSpeed * inputMov.x  // Movimiento hacia izquierda y derecha del PJ
                                  + new Vector3(0, _rigidbody.velocity.y, 0); // Para hacer que baje por la gravedad
        }
        else
        {
            _rigidbody.velocity = transform.forward * speed * inputMov.y  // Movimiento hacia adelante y atr�s del PJ
                                  + transform.right * speed * inputMov.x  // Movimiento hacia izquierda y derecha del PJ
                                  + new Vector3(0, _rigidbody.velocity.y, 0); // Para hacer que baje por la gravedad
        }
    }
    

    //Para controlar que no hagas doble salto
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("terra"))
        {
            jumping = false;
        }
    }
}
