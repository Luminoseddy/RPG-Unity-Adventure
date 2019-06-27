using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float duration = 5f; // how long it takes before it explodes
    public float radius = 3f;// Radius of explosion
    private float explosionTimer; // Timer for bomb to wait
    public float explosionDuration = 0.20f;
    private bool exploded;
    public GameObject explosionModel;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * 5;
        explosionTimer = duration;
        explosionModel.transform.localScale = Vector3.one * radius;
        explosionModel.SetActive(false); // start the radius explosion invisible
    }

    // Update is called once per frame
    void Update()
    {
        explosionTimer -= Time.deltaTime;

        if(explosionTimer <= 0f && exploded == false){
            exploded = true;
            // explodes wider than the object, (current position, radius)
            // the objects hit are stored in an array.
            Collider[] hitObjects = Physics.OverlapSphere(transform.position, radius);

            // This test the objectgs that are hit by the bomb.
            // Loop over all enemies that are hit by the bomb and store in Collider
            foreach (Collider collider in hitObjects){
                Debug.Log(collider.name + " was hit.");
                if(collider.GetComponent<Enemy> () != null){
                    collider.GetComponent<Enemy>().Hit(); 
                }
            }
            StartCoroutine(Explode());
        }      
    }

    private IEnumerator Explode(){
        explosionModel.SetActive(true);
        yield return new WaitForSeconds(explosionDuration);
        Destroy(gameObject);
    }
}
