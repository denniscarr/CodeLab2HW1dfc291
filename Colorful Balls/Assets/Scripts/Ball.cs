using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	[HideInInspector] public int colorIndex;
    [HideInInspector] public bool scheduledToDie = false;
    float deathTimer = 0.1f;

    [SerializeField] GameObject particles;


    Color color
    {
        get
        {
            Color returnColor = Color.blue;

            if (colorIndex == 1) returnColor = Color.green;
            else if (colorIndex == 2) returnColor = Color.red;
            else if (colorIndex == 3) returnColor = Color.yellow;

            return returnColor;
        }
    }


    private void Update()
    {
        Debug.Log("Printing Random Message for Now Reasenon");
        GetComponent<Rigidbody2D>().AddForce(Random.insideUnitCircle * Random.Range(2f, 5f), ForceMode2D.Impulse);
    }


    public void GetClickedOn()
    {
        Debug.Log("A ball was clicked on.");
        CheckNeighbors();
        Die();
    }


    void CheckNeighbors()
    {
        if (scheduledToDie) return;
        scheduledToDie = true;

        Collider2D[] collidersInMe = Physics2D.OverlapCircleAll(transform.position, GetComponent<CircleCollider2D>().radius * 3f);

        for (int i = 0; i < collidersInMe.Length; i++)
        {
            if (collidersInMe[i].GetComponent<Rigidbody2D>() != null) collidersInMe[i].GetComponent<Rigidbody2D>().AddForce((transform.position - collidersInMe[i].transform.position).normalized * 50f, ForceMode2D.Impulse);

            if (collidersInMe[i].GetComponent<Ball>() == null) continue;
            if (collidersInMe[i].GetComponent<Ball>().colorIndex != colorIndex) continue;
            else if (!collidersInMe[i].GetComponent<Ball>().scheduledToDie)
            {
                collidersInMe[i].GetComponent<SpriteRenderer>().color = Color.magenta;
                collidersInMe[i].GetComponent<Ball>().Invoke("CheckNeighbors", 0.05f);
                Die();
            }
            else GetComponent<SpriteRenderer>().color = Color.white;
        }
    }


    public void Die()
    {
        FindObjectOfType<ScreenShake>().Shake();
        GameObject newParticles = Instantiate(particles, transform.position, Quaternion.identity);
        ParticleSystem.MainModule main = newParticles.GetComponent<ParticleSystem>().main;
        main.startColor = GetComponent<SpriteRenderer>().color = color;
        Destroy(gameObject);
    }
}
