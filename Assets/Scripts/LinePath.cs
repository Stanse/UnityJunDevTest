using UnityEngine;

public class LinePath : Path
{
    Vector2 finishPoint;

    // Start is called before the first frame update
    void Start()
    {
        pointA = new Vector2(-8.4f, 2f);
        pointB = new Vector2(8.4f, 2f);
        finishPoint = new Vector2(pointB.x, pointB.y);
    }

    override public void StartMoving(GameObject obj)
    {
        movingObject = obj;
        speed = movingObject.GetComponent<Ball>().GetSpeed();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(movingObject != null)
        {
            if (movingObject.transform.position.x == this.finishPoint.x)
            {
                finishPoint.x *= -1;
                movingObject.GetComponent<Ball>().ChangeDirectionOfRotation();
            }
            speed = movingObject.GetComponent<Ball>().GetSpeed();
            float step = Time.deltaTime * speed;
            movingObject.transform.position = Vector2.MoveTowards(movingObject.transform.position, finishPoint, step);
        }
    }
}
