using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyComponent : MonoBehaviour
{
    public int speed;
    public bool moveRight;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(moveRight)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime, 0, 0); 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("tube") || collision.gameObject.CompareTag("enemy"))
        {
            if (moveRight)
            {
                moveRight= false;
            }
            else
            {
                moveRight= true;    
            }
        }

        if(collision.gameObject.tag == "player")
        {
            float yOffset = 0.5f;
            if(transform.position.y + yOffset < collision.transform.position.y)
            {
                Destroy(gameObject);
            }
        }
    }

}
