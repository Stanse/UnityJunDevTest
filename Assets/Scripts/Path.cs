using UnityEngine;

public abstract class Path : MonoBehaviour
{
    [SerializeField] protected Vector2 pointA;
    [SerializeField] protected Vector2 pointB;
    [SerializeField] protected float speed;
    [SerializeField] protected GameObject movingObject;

    public Vector2 getPointA()
    {
        return pointA;
    }

    public Vector2 getPointB()
    {
        return pointB;
    }

    public abstract void StartMoving(GameObject obj);
}
