using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombz : MonoBehaviour {

    [SerializeField]
    GameObject aim;

    [SerializeField]
    GameObject bomb;

    [SerializeField]
    GameObject theEnirePrefab;

    [SerializeField]
    GameObject car;

    [SerializeField]
    Rigidbody carRB;

    [SerializeField]
    float bombFallSpeed;

    [SerializeField]
    GameObject effect;

    [SerializeField]
    float explosionRadius = 5;

    [SerializeField]
    float explosionPower = 10;

    [SerializeField]
    AudioSource SoundSource;

    [SerializeField]
    AudioSource SoundSourceExplosion;

    [SerializeField]
    AudioClip SoundExplosion;

    bool soundWasPlayed = false;

    bool reliseTheBomb = false;

  


    // Use this for initialization
    void Start () {
         
        
		
	}

    // Update is called once per frame
    void Update() {

        if (reliseTheBomb == true)
        {

            aim.SetActive(true);

            bomb.SetActive(true);
            bomb.transform.Translate(Vector3.down * Time.deltaTime * bombFallSpeed, Space.Self);

            aim.transform.localScale -= new Vector3(0.18f, 0, 0.18f) * Time.deltaTime;
            aim.transform.localPosition += new Vector3(0.93f, 0, 0.93f) * Time.deltaTime;


           

            StartCoroutine( Explode());
            

        }
		
	}

 

    void OnTriggerEnter(Collider c_collider)
    {

        if ( c_collider.gameObject == car)
        {
            reliseTheBomb = true;
            SoundSource.Play();

            //   PlayExplosion();
            

        }
    }

    void Explosion()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(explosionPower, explosionPos, explosionRadius, 3.0F);
                carRB.AddExplosionForce(explosionPower * 10, explosionPos, explosionRadius, 3.0F);
        }
        
    }

    IEnumerator Explode ()
    {
        yield return new WaitForSeconds(2);

        effect.transform.localScale += new Vector3(6, 6, 6) * Time.deltaTime;


        effect.SetActive(true);

        if (soundWasPlayed == false)
        {

            SoundSourceExplosion.Play();
            soundWasPlayed = true;

        }


        print("KABOOOOM!");

        aim.GetComponentInChildren<Renderer>().enabled = false;

        bomb.SetActive(false);

        Explosion();
        yield return new WaitForSeconds(1f);
        theEnirePrefab.SetActive(false);

    }

    IEnumerator PlayExplosion()
    {

        yield return new WaitForSeconds(2);
        SoundSourceExplosion.Play();


    }
}
