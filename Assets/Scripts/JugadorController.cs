using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class JugadorController : MonoBehaviour
{

    //Declarlo la variable de tipo RigidBody que luego asociaremos a nuestro
    private Rigidbody rb;

    public float velocidad;
    private int contador;
    public Text textoContador, textoGanar;
    public AudioSource coinSound;

    // Start is called before the first frame update
    void Start()
    {
        
        // textoContador = GameObject.Find("textoContador");
        rb = GetComponent<Rigidbody>();
        contador=0;

        setTextoContador();
        //Inicio el texto de ganar a vacío
        textoGanar.text = "";   
    }

    void FixedUpdate () {
        //Estas variables nos capturan el movimiento en horizontal y
        // vertical de nuestro teclado  
        float movimientoH = Input.GetAxis("Horizontal");
        float movimientoV = Input.GetAxis("Vertical");

        //Un vector 3 es un trío de posiciones en el espacio XYZ, en este
        // caso el que corresponde al movimiento
        Vector3 movimiento = new Vector3(movimientoH, 0.0f,
        movimientoV);

        //Asigno ese movimiento o desplazamiento a mi RigidBody
        rb.AddForce(movimiento*velocidad);
    }
    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Coleccionable")){
            other.gameObject.SetActive(false);
            coinSound.Play();
            contador = contador+1;
            setTextoContador();
        }
    }
    void setTextoContador(){
        textoContador.text = "Contador: " + contador.ToString();
        if (contador >= 8){
            textoGanar.text = "¡Ganaste!";
        }
    }
}
