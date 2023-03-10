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

    private Animator anim;
    public float X, Y;

   
    // Start is called before the first frame update
    void Start()
    {
        // Recuperamos el componente Rigidbody del player para poder trabajar con el
        _rigidbody = GetComponent<Rigidbody>();

        anim = GetComponent<Animator>();

        

    }

    // Update is called once per frame
    void Update()
    {
        // Leemos los inputs para el desplazamiento del jugador

        X = Input.GetAxis("Horizontal");
        Y = Input.GetAxis("Vertical");
         inputMov.x = Input.GetAxis("Horizontal");
         inputMov.y = Input.GetAxis("Vertical");
        
        anim.SetFloat("VelX",X);
        anim.SetFloat("VelY",Y);

        // logica de salto
        if (Input.GetKeyDown(KeyCode.Space) && jumping == false)
        {
            _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumping = true;
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
