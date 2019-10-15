using UnityEngine;

public abstract class Path : MonoBehaviour
{
    [SerializeField] protected Vector2 pointA;
    [SerializeField] protected Vector2 pointB;
    [SerializeField] protected float speed;
    [SerializeField] protected GameObject movingObject;

    public Vector2 GetPointA()
    {
        return pointA;
    }

    public Vector2 GetPointB()
    {
        return pointB;
    }

    public abstract void StartMoving(GameObject obj);
}
