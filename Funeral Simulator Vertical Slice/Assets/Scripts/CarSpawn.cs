using UnityEngine;
using System.Collections;

public class CarSpawn : MonoBehaviour {

    [SerializeField]
   public Rigidbody m_car;

    [SerializeField]
    Transform m_SpawnPoint;

    [SerializeField]
    int speed;

    [SerializeField]
    float spawnratio;

    int carnum;

    bool doTheSpawn = false;

    

   
    // Use this for initialization
    void Start () {

        
	
	}
	
	// Update is called once per frame
	void Update () {

      
    }

    void SpawnCar()
    {
        
        Rigidbody carInstance =
           Instantiate(m_car, m_SpawnPoint.position, m_SpawnPoint.rotation) as Rigidbody;


        carInstance.velocity = speed * m_SpawnPoint.forward;
        doTheSpawn=false;

        carnum++;

    }

    IEnumerator CarSpawnSequence()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnratio);
            if (doTheSpawn == false)
            {
                doTheSpawn = true;
                SpawnCar(); }
        }

    }

    void Awake()
    {
        StartCoroutine(CarSpawnSequence());
    }

}
