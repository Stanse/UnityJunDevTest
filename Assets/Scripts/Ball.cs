using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] private float spriteAngleRotation;
    public float angleStep;
    // Start is called before the first frame update

    public void SetSpeed(float s)
    {
        speed = s;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public void SetSpriteAngleRotation(float angle)
    {
        spriteAngleRotation = angle;
    }

    public void ChangeDirectionOfRotation()
    {
        angleStep *= -1;
    }

    void Start()
    {
        speed = 1;
        spriteAngleRotation = 0;
        angleStep = -10;
    }

    // Update is called once per frame
    void Update()
    {

        //transform.position = new Vector3(3f, 0,0);
        if(this != null)
        {
            //Debug.Log("rotate sprite");
            spriteAngleRotation += angleStep * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, spriteAngleRotation);
        }
        
    }
}
