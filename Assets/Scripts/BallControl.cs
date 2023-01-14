using System.Threading.Tasks;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public float ballSpeed = 100f;
    public AudioSource audioFile;



    void Start()
    {
        Invoke("GoBall", 2.0f);
    }

    private void Update()
    {
        float velocityX = GetComponent<Rigidbody2D>().velocity.x;
        if (velocityX < 18 && velocityX > -18 && velocityX != 0)
        {
            if (velocityX > 0)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(20, GetComponent<Rigidbody2D>().velocity.y);
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-20, GetComponent<Rigidbody2D>().velocity.y);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {


            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, (GetComponent<Rigidbody2D>().velocity.y / 2) + (collision.collider.GetComponent<Rigidbody2D>().velocity.y / 3));
            audioFile.pitch = Random.Range(0.8f, 1.2f);
            audioFile.Play();
        }
    }

    void GoBall()
    {
        float randomNumber = Random.Range(0, 2);

        if (randomNumber <= 0.5)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(ballSpeed, 0));
        }
        else
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-ballSpeed, -0));
        }
    }

    public void ResetBall()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        transform.position = new Vector2(0f, 0f);
        Invoke("GoBall", 1f);
    }
}
