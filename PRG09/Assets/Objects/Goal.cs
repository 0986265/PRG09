using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameObject goalBlocker;

    private void Update()
    {
        if(GameManager.instance.GetScore() >= 1 && goalBlocker.activeSelf == false)
        {
            goalBlocker.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ball")
        {
            Debug.Log("Scored");
            StartCoroutine(RespawnBall(other.gameObject));
            GameManager.instance.AddScore();
        }
    }

    IEnumerator RespawnBall(GameObject ball)
    {
        ball.GetComponentInChildren<ParticleSystem>().Play();
        yield return new WaitForSeconds(3f);
        ball.GetComponentInChildren<ParticleSystem>().Stop();
        ball.transform.position = new Vector3(0, 1.5f, 0);
        ball.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
    }
}
