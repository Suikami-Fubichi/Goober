using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public GameObject spawnpoint;
    public float amplitude = 0.5f;
    public float frequency = .5f;
    Vector3 posOrigin = new Vector3();
    Vector3 tempPos = new Vector3();
    private AudioSource src;
    // Start is called before the first frame update
    void Start()
    {
        posOrigin = transform.position;
        src = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        tempPos = posOrigin;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;
        transform.position = tempPos;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        spawnpoint.transform.position = transform.position;
        src.Play();
    }

}
