using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : MonoBehaviour
{
    public bool isAlive = true;
    public SpriteRenderer spriteRenderer;
    public Sprite deathSprite;
    public Sprite victorySprite;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        CannonBall cannonBallCollision = collision.collider.GetComponent<CannonBall>();
        //King kingCollision = collision.collider.GetComponent<King>();

        /*
        if (collision.collider)
        {
            print(collision.relativeVelocity.magnitude);
        }
        */

        // If cannonball has collided (with the king) with a velocity > 2, the king dies.
        if (cannonBallCollision != null && collision.relativeVelocity.magnitude > 2)
        {
            GetComponent<King>().isAlive = false;
            defeat();
            return;
        }

        // If anything else collides (with the king) with a velocity > 3, the king dies.
        if (collision.relativeVelocity.magnitude > 3)
        {
            GetComponent<King>().isAlive = false;
            defeat();
            return;
        }
    }

    // King goes to the victory pose (default sprite changes to the attack sprite)
    public void victory()
    {
        spriteRenderer.sprite = victorySprite;
    }

    // King dies (default sprite changes to the death sprite)
    public void defeat()
    {
        spriteRenderer.sprite = deathSprite;
    }
}
