using System;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public static Action damageEvent;
    private AudioSource src;
    // Start is called before the first frame update
    void Start()
    {
        src = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Player"){
            src.Play();
            damageEvent?.Invoke();
        }
    }
}
