using System;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public static Action damageEvent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Player"){
            damageEvent?.Invoke();
        }
    }
}
