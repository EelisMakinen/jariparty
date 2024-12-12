using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using UnityEngine.Splines;
using UnityEngine.SceneManagement;

public class PlayerMover : MonoBehaviour
{
    
    public GameObject SplineGameObject;
    private SplineContainer spline;
    private BezierKnot[] bezierKnots;
    private Vector3 splinePosition;
    public int currentPoint;

    public int targetPoint;
    // Start is called before the first frame update
    void Start()
    {
        currentPoint = 0;
        targetPoint = 0;

        spline = SplineGameObject.GetComponent<SplineContainer>();
        Spline path = spline.Splines[0];
        bezierKnots = path.Knots.ToArray();
        splinePosition = spline.transform.position;
        transform.position = bezierKnots[currentPoint].Position;
        transform.position += splinePosition;
        
    }

    // Update is called once per frame
    void Update()
    {

        while(targetPoint >= bezierKnots.Length)
        {
            targetPoint -= bezierKnots.Length;
        }
        if(targetPoint < 0) 
        {
            targetPoint = 0;
        }
        // Move to the new place
        // Only move one step at a time
        if (currentPoint != targetPoint)
        {
            // Keep moving
            if (currentPoint != targetPoint)
            {
                // Where is next point
                Vector3 target;
                target = bezierKnots[targetPoint].Position;
                target += splinePosition;

                transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * 10f);
                if ((transform.position - target).magnitude < 0.1f)
                {
                    // Arrived
                    currentPoint = targetPoint;
                }
            }
        }
        if(currentPoint == 58)
        {
            SceneManager.LoadScene("FinishLine");
        }
    }
}