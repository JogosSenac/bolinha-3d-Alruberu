using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BolinhaMove : MonoBehaviour
{
    private float moveH; private float moveV;
    private Rigidbody rb;
    [SerializeField] private float velocidade; [SerializeField] private float forcaPulo;
    [SerializeField] private bool invertH; [SerializeField] private bool invertV;
    [SerializeField] private int pontos;
    private TextMeshProUGUI textoPontos;
    private TextMeshProUGUI textoTotal;
    public bool estaVivo = true;
    public bool podePular;

    [Header("Sons Bolinha")]
    [SerializeField] private AudioClip pulo;
    [SerializeField] private AudioClip pegarCubo;
    private AudioSource audioPlayer;
 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioPlayer = GetComponent<AudioSource>();
        textoPontos = GameObject.FindGameObjectWithTag("Pontos").GetComponent<TextMeshProUGUI>();
        textoTotal = GameObject.Find("Total").GetComponent<TextMeshProUGUI>();
        textoTotal.text = GameObject.FindGameObjectsWithTag("CuboA").Length.ToString();
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
            if(podePular && Input.GetKeyDown(KeyCode.Space)) 
            {
                rb.AddForce(transform.up * forcaPulo, ForceMode.Impulse);
                audioPlayer.PlayOneShot(pulo);
                Debug.Log("pode pular");
                podePular = false;

            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            velocidade = velocidade * 3;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            velocidade = velocidade / 3;
        }
            
        }
        
        if (pontos == 5)
        {
            SceneManager.LoadScene("Fase2");
        }

    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("CuboA"))
        Destroy(other.gameObject);
        audioPlayer.PlayOneShot(pegarCubo);
        pontos++;
        textoPontos.text = pontos.ToString();
        

    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("buraco"))
        {
            SceneManager.LoadScene("Morte");
            estaVivo = false;
        }
        
        if (other.gameObject.CompareTag("chao"))
        {
            podePular = true;
            Debug.Log("pode pular");

        }

    }

}