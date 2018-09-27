using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGenerator : MonoBehaviour {
    [Header("Titulo de ejemplooo")]
    [SerializeField] Transform tuberias;
    [SerializeField] float Ratiotuberias= 3.5f;

    // Use this for initialization
    void Start () {
        InvokeRepeating("GeneratePipe", 0, Ratiotuberias);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void GeneratePipe ()
    {
        if (GameConfig.IsPlaying())
        {
            Instantiate(tuberias, transform.position, Quaternion.identity);
        }
    }
}
