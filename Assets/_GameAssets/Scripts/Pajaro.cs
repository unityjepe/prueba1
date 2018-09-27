using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pajaro : MonoBehaviour {

    [SerializeField] Text marcador;
    [SerializeField] ParticleSystem sangre;
    [SerializeField] float fuerza = 300f;
    [SerializeField] AudioSource audiosor;
    [SerializeField] AudioSource audiopuntaje;
    [SerializeField] AudioSource audioaleteo;
    Rigidbody rb;
    
    int puntos = 0;

    void Start () {
       
        rb = GetComponent<Rigidbody>();
        marcador.text = "Score: " + puntos;
    }

	void Update () {
        if (Input.GetKeyDown("space"))
        {
            audioaleteo.Play();
            rb.AddForce(transform.up * fuerza);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        puntos++;
        audiopuntaje.Play();
        Debug.Log(puntos.ToString());
        marcador.text = "Score: " + puntos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //GetComponent<SoundGeneratorScript>();
        audiosor.Play();
        //DETENEMOS EL JUEGO
        GameConfig.Stop();

        //INSTANCIAR SISTEMA DE PARTICULAS
        Instantiate(sangre, transform.position, Quaternion.identity);

        //DESACTIVAR EL RENDERER DEL PAJARO si comentamos funciona el audio
        gameObject.SetActive(false);

        //FINALIZAMOS LA PARTIDA TRAS UN DELAY
        Invoke("FinalizarPartida", 0.5f);
    }

    private void FinalizarPartida()
    {
       
        Destroy(this.gameObject);
        SceneManager.LoadScene(0);
        GameConfig.Play();
    }
}
