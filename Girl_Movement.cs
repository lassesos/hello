using System.Runtime.InteropServices;
using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
    public bool mortal;
    public bool timer=false;
    public float timeleft;
    public bool test;
    public float score;
    public float restraint_right;
    public float restraint_left;
    public bool bomb = false;
    
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if (bomb == true)
	    {
            GameObject[] gos = GameObject.FindGameObjectsWithTag("spider");
            
            foreach (GameObject go in gos)

                Destroy(go);
	        bomb = false;
	    }
        
        score += Time.deltaTime * 1;

        if (timer == true)
        {
            timeleft += Time.deltaTime * 1;
        }
        if (timeleft > 4)
        {
            timer = false;
            timeleft = 0;
            mortal = true;
        }
        if (transform.position.x < restraint_right && (Input.GetKey(KeyCode.RightArrow)))
        {
            transform.Translate(new Vector3(10, 0, 0) * Time.deltaTime);
        }
        if (transform.position.x > restraint_left && Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(-10, 0, 0) * Time.deltaTime);
        }
	}
    void OnTriggerEnter(Collider other)
    {

        if (mortal == true && other.tag == "spider")
        {
            other.audio.Play();
            Debug.Log(score);
            Destroy(gameObject);
            
        }
        if (other.name == "immortal powerup") ;
        {
            timer = true;
            mortal = false;
            Destroy(other.gameObject);
        }
        if (other.name == "bomb")
        {
            Debug.Log("hej");
            bomb = true;
        }

    }
}
