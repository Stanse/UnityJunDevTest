using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawPath : Path
{
    Vector2 finishPoint;
    public List<Vector2> pathPoints;
    public int nextPoint;
    private int direction;
    public int N;


    // Start is called before the first frame update
    void Start()
    {
        N = 8;
        pointA = new Vector2(-8.4f, 2f);
        pointB = new Vector2(8.4f, 2f);
        nextPoint = 0;
        direction = 1;
        finishPoint = new Vector2();
    }

    override public void StartMoving(GameObject obj)
    {
        if (pathPoints.Count > 0)
            pathPoints.Clear();
        nextPoint = 0;
        direction = 1;
        movingObject = obj;
        speed = movingObject.GetComponent<Ball>().GetSpeed();

        float pathLenght = Mathf.Abs(pointB.x - pointA.x);

        pathPoints.Add(pointA);
        for(int i = 1; i <= N; i++)
        {
            float x = pointA.x + (pathLenght / N) * i;
            float y = pointA.y;

            if (i % 2 != 0)
                y = 4f;

            pathPoints.Add(new Vector2(x,y));
        }
        pathPoints.Add(pointB);
        finishPoint = pathPoints[nextPoint];
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (movingObject != null)
        {
           
            if (movingObject.transform.position.x == this.finishPoint.x)
            {
                if (nextPoint >= pathPoints.Count-1)
                {
                    direction *= -1;
                    movingObject.GetComponent<Ball>().ChangeDirectionOfRotation();
                }
                nextPoint += direction;
                if (nextPoint == 0)
                {
                    direction *= -1;
                    movingObject.GetComponent<Ball>().ChangeDirectionOfRotation();
                }
                finishPoint = pathPoints[nextPoint];
            } 
            speed = movingObject.GetComponent<Ball>().GetSpeed();
            float step = Time.deltaTime * speed;
            movingObject.transform.position = Vector2.MoveTowards(movingObject.transform.position, finishPoint, step);
        }

    }

    public void setN(int n)
    {
        N = n;
    }

    public int getN()
    {
        return N;
    }
}
