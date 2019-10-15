using UnityEngine;

public class SpiralPath : Path
{
    Vector2 finishPoint;
    Vector2 nextpoint;
    [SerializeField] private float radius;
    [SerializeField] private float angle;
    private float deltaR;
    private float deltaAngle;

    // Start is called before the first frame update
    void Start()
    {
        pointA = new Vector2(0f, 4.5f);
        pointB = new Vector2(0f, 0f);
        finishPoint = new Vector2(pointB.x, pointB.y);
        nextpoint = new Vector2(pointA.x, pointA.y);
        radius = pointA.y;
        deltaR = -0.9f;
        angle = 90;
        deltaAngle = .2f;
    }

    override public void StartMoving(GameObject obj)
    {
        movingObject = obj;
        speed = movingObject.GetComponent<Ball>().GetSpeed();

        radius = pointA.y;
        deltaR = -0.9f;
        angle = 90;
        deltaAngle = .2f;

        nextpoint.Set(pointA.x, pointA.y);
    }

    public float getRadius()
    {
        return radius;
    }

    public void SetRadius(float r)
    {
        radius = r;
    }

    void FixedUpdate()
    {
        if (movingObject != null)
        {
            if (movingObject.transform.position.x == nextpoint.x && movingObject.transform.position.y == nextpoint.y)
            {
                radius += deltaR * Time.deltaTime;
                if (radius < 0)
                { 
                    deltaR *= -1;
                    deltaAngle *= -1;
                    angle = 0;
                }
                if (movingObject.transform.position.y > pointA.y)
                {
                    deltaR *= -1f;
                    deltaAngle *= -1;
                }
                angle += deltaAngle;
                    
                float x = radius * Mathf.Cos(angle);
                float y = radius * Mathf.Sin(angle);
                nextpoint.Set(x, y);
            }
            speed = movingObject.GetComponent<Ball>().GetSpeed();
            float step = Time.deltaTime * speed;

            movingObject.transform.position = Vector2.MoveTowards(movingObject.transform.position, nextpoint, step);
            /*radius -= .9f * Time.deltaTime;
            angle += .2f;
            if (angle > 360)
                angle = 0;
            float x = radius * Mathf.Cos(angle);
            float y = radius * Mathf.Sin(angle);
            nextpoint.Set(x, y);
            Instantiate(movingObject, new Vector3(x,y,0), movingObject.transform.rotation);*/
        }

    }
}
