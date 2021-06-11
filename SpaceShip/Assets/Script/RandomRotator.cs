using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour
{
    public GameObject playerExplosion;
    public GameObject asteroidExplosion;
    public float rotation;
    public float speed;

    float multiplier;

    void Start()
    {
        Rigidbody asteroid = GetComponent<Rigidbody>();
        asteroid.angularVelocity = Random.insideUnitSphere * rotation;
        multiplier = Random.Range(0.5f, 2.0f);
        asteroid.velocity = new Vector3(0, 0, -speed / multiplier);
        transform.localScale *= multiplier;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Asteroid")
        {
            return;
        }
        if( other.tag == "Bondary")
        {
            if (GameController.score > 100)
            {
                GameController.score -= 15;
            }
            return;
        }
        GameObject newExplosion = Instantiate(asteroidExplosion, transform.position, Quaternion.identity);
        if(other.tag == "LazerShot")
        {
            GameController.score += 50;
        }
        if(other.tag == "Player")
        {
            Instantiate(playerExplosion, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
        Destroy(other.gameObject);
        

    }
}