using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuberias : MonoBehaviour {//MonoBehaviour contiene clases propias d unity como collision

    [SerializeField] int speed = 3; //serializeField permite modificar los parametros desde la interfaz de unity
    [SerializeField] float limitInferior= -4;
    [SerializeField] float limitSuperior = 4;
    [SerializeField] float DistanciaDestruccion = -8;

    // Use this for initialization
    void Start () {
        float factorPosicion = Random.Range(limitInferior, limitSuperior);
        transform.position = new Vector3
            (
            transform.position.x,
            transform.position.y + factorPosicion,
            transform.position.z
            );
	}
	
	// Update is called once per frame
	void Update () {

        if (GameConfig.IsPlaying())
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            if (transform.position.x < DistanciaDestruccion)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
