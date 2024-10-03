using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class BolinhaMove : MonoBehaviour
{
    private float moveH; private float moveV;
    private Rigidbody rb;
    [SerializeField] private float velocidade; [SerializeField] private float forcaPulo;
    [SerializeField] private bool invertH; [SerializeField] private bool invertV;
    [SerializeField] private int pontos;
    private bool estaVivo = true;

    [Header("Sons Bolinha")]
    [SerializeField] private AudioClip pulo;
    [SerializeField] private AudioClip pegarCubo;
    private AudioSource audioPlayer;
 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioPlayer = GetComponent<AudioSource>();
    }
 
    // Update is called once per frame
    void Update()
    {

        if (estaVivo) //Se está vico pode se mover
        {
            moveH = Input.GetAxis("Horizontal");
            moveV = Input.GetAxis("Vertical");
    
            transform.position += new Vector3(moveH * velocidade * Time.deltaTime, 0 , moveV * velocidade * Time.deltaTime);
 
            //PULO
            if(Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(transform.up * forcaPulo, ForceMode.Impulse);
                audioPlayer.PlayOneShot(pulo);
            }
        }

    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("CuboA"))
        Destroy(other.gameObject);
        audioPlayer.PlayOneShot(pegarCubo);
        pontos++;

    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("Buraco"))
        {
            estaVivo = false;
        }
    }

}