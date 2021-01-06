using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CannonScript1 : MonoBehaviour
{
    public int MaxShots;
    public GameObject CannonBall;
    public GameObject CannonBallBig;
    public float CannonBallBigAmount;
    public float CoordTest, CoordTestBig, CoordMin, CoordMax, CoordMinBig, CoordMaxBig, Multiplier, MultiplierBig;
    private Vector2 _Target;
    private Vector2 _TargetBig;
    private int TotalShots = 0;
    private float i;

    void Start()
    {
        i = Time.time;      // save the amount of time the Time.timeScale has been set to 1. 
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Time.time > i)      // Run the if statement every 2 seconds.
        {
            i += 2;

            if (TotalShots <= MaxShots)     // Keep track of how many shots have been shot, Prepare victory screen when if statement is false.
            {
                CreateTargetVector();
                CreateCannonBallInstance();        
            }
            else if (TotalShots >= MaxShots)
            {
                ShootingOver();
            }
            TotalShots += 1;
        }
    }

    // Create a new random target vector for each shot. 
    // If we are using test coordinates (CoordTest != 0) all of the cannonballs are shot to the same spot.
    void CreateTargetVector()
    {
        print("vector");
        if (CoordTest != 0)
        {
            _Target = new Vector2(20, CoordTest);

        }
        else if (CoordTest == 0)
        {
            _Target = new Vector2(20, Random.Range(CoordMin, CoordMax));
        }

        if (CoordTestBig != 0)
        {
            _TargetBig = new Vector2(20, CoordTestBig);
        }

        else if (CoordTestBig == 0)
        {
            _TargetBig = new Vector2(20, Random.Range(CoordMinBig, CoordMaxBig));
        }
        //print("TARGET KOORDINAATTI: " + _Target);
    }

    // Creates an instance of the CannonBall/CannonBallBig gameobject and adds force towards the target vector.
    void CreateCannonBallInstance()
    {
        print("shoot");
        if (TotalShots < CannonBallBigAmount)
        {
            var CannonBallBigInstance = Instantiate(CannonBallBig, transform.position, Quaternion.identity);
            CannonBallBigInstance.AddComponent<Rigidbody2D>();
            var CannonRBBig = CannonBallBigInstance.GetComponent<Rigidbody2D>();
            CannonRBBig.AddForce(_TargetBig * MultiplierBig);
        }

        else if (TotalShots > CannonBallBigAmount)
        {
            var CannonBallInstance = Instantiate(CannonBall, transform.position, Quaternion.identity);
            CannonBallInstance.AddComponent<Rigidbody2D>();
            var CannonRB = CannonBallInstance.GetComponent<Rigidbody2D>();
            CannonRB.AddForce(_Target * Multiplier);
        }
    }

    // When the cannon is done with the shooting, the king goes to the victory pose and after 2 seconds loads the LevelCompleted scene.
    void ShootingOver()
    {
        print("victory");
        if (TotalShots > MaxShots + 1)
        {
            FindObjectOfType<King>().victory();
        }

        if (TotalShots > MaxShots + 2 && FindObjectOfType<King>().isAlive == true)
        {
            SceneManager.LoadScene("LevelCompleted");
            return;
        }
        else if (FindObjectOfType<King>().isAlive == false)
        {
            FindObjectOfType<King>().defeat();
            return;
        }
    }
}
