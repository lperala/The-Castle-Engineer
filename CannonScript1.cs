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
        i = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Time.time > i)
        {
            i += 2;
            if (TotalShots <= MaxShots)
            {
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
            TotalShots += 1;
            //print("CURRENT SHOTS: " + TotalShots);
            //print("MAX SHOTS: " + MaxShots);
        }

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
