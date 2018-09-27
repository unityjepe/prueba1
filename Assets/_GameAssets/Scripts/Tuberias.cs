using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuberias : MonoBehaviour {//MonoBehaviour contiene clases propias d unity como collision

    [SerializeField] int speed = 3; //serializeField permite modificar los parametros desde la interfaz de unity

	// Use this for initialization
	void Start () {
        float factorPosicion = Random.Range(-4, 4);
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
            if (transform.position.x < -8)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
