using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWalls : MonoBehaviour
{
    public AudioSource audioFile;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Ball")
        {
            audioFile.pitch = Random.Range(0.8f, 2f);
            audioFile.Play();

            GameManager.Score(transform.name);
            collision.gameObject.SendMessage("ResetBall");

        }
    }
}
