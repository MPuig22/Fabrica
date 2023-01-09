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
    private Vector2 inputRot;
    private Rigidbody _rigidbody;
    private float rotX;

    private Vector3 movement;
    private bool jumping;
    public float jumpForce;
    private bool isRunning;

   
    // Start is called before the first frame update
    void Start()
    {
        // Recuperamos el componente Rigidbody del player para poder trabajar con el
        _rigidbody = GetComponent<Rigidbody>();

        rotX = playerCamera.eulerAngles.x; // rotacion vertical de la camara

    }

    // Update is called once per frame
    void Update()
    {
        // Leemos los inputs para el desplazamiento del jugador
        inputMov.x = Input.GetAxis("Horizontal");
        inputMov.y = Input.GetAxis("Vertical");
        //Imputs rotacion del jugador
        inputRot.x = Input.GetAxis("Mouse X") * sensibilityMouse;
        inputRot.y = Input.GetAxis("Mouse Y") * sensibilityMouse;

        // Metodo de la rotacion de la camera
        MovePlayerCamera();

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
            _rigidbody.velocity = transform.forward * runSpeed * inputMov.y  // Movimiento hacia adelante y atrás del PJ
                                  + transform.right * runSpeed * inputMov.x  // Movimiento hacia izquierda y derecha del PJ
                                  + new Vector3(0, _rigidbody.velocity.y, 0); // Para hacer que baje por la gravedad
        }
        else
        {
            _rigidbody.velocity = transform.forward * speed * inputMov.y  // Movimiento hacia adelante y atrás del PJ
                                  + transform.right * speed * inputMov.x  // Movimiento hacia izquierda y derecha del PJ
                                  + new Vector3(0, _rigidbody.velocity.y, 0); // Para hacer que baje por la gravedad
        }
    }

    public void MovePlayerCamera()
    {
        rotX -= inputRot.y;
        rotX = Mathf.Clamp(rotX, -20, 25); // Establecemos límites en la rotación vertical de la cámara
        transform.Rotate(0, inputRot.x * sensibilityMouse, 0f); // Rotación horizontal de la cámara
        playerCamera.transform.localRotation = Quaternion.Euler(rotX, 0f, 0f); // Rotación vertical de la cámara
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
