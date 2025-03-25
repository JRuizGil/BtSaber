using UnityEngine;

public class MovingObject : MonoBehaviour
{
    private float targetZ;
    private float speed;
    public float destroyTime = 5f;

    public void Initialize(float targetZ, float speed)
    {
        this.targetZ = targetZ;
        this.speed = speed;
    }
    void Start()
    {
        Invoke("DestroySelf", destroyTime);
    }
    void Update()
    {
        transform.position += Vector3.forward * speed * Time.deltaTime;
    }
    
}