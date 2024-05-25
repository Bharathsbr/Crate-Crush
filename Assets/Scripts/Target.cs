using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody rb;
    private GameManager gm;
    public int pointValue=0;
    public ParticleSystem explosion;
    

    private void Awake()
    {
        rb=GetComponent<Rigidbody>();
        gm=GameObject.Find("Game Manager").GetComponent<GameManager>();
        rb.AddForce(Vector3.up*Random.Range(14,17),ForceMode.Impulse);
        rb.AddTorque(Random.Range(-10,10),Random.Range(-10,10),Random.Range(-10,10),ForceMode.Impulse);
        transform.position=new Vector3(Random.Range(-4,4),-4);
    }
    
    private void OnMouseDown(){
        if(gm.isGameActive){
            Destroy(gameObject);
            Instantiate(explosion,transform.position,explosion.transform.rotation);
            gm.UpdateScore(pointValue);
        }
    }

    private void OnTriggerEnter(Collider other){
        Destroy(gameObject);
        if(!other.gameObject.CompareTag("Bad")){
            gm.GameOver();
        }
    }
}
