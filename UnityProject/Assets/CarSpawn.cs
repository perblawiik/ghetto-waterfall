using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawn : MonoBehaviour {

    public GameObject carPrefab;
    private float timer;
    public float spawnTime;

	// Use this for initialization
	void Start () {
        timer = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > spawnTime)
        {
            timer = 0.0f;
            Instantiate(carPrefab, transform.position, transform.localRotation);
        }
	}
}
