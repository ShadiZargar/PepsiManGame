using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Forward Movement")]
    public float forwardSpeed = 8f;

    [Header("Lane Movement")]
    public float laneOffset = 2.5f;   
    public float laneChangeSpeed = 12f;

    private int currentLane = 1; 
    private bool isAlive = true;

    void Update()
    {
        if (!isAlive) return;

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            ChangeLane(-1);

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            ChangeLane(+1);

        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime, Space.World);

        Vector3 targetPos = transform.position;
        targetPos.x = LaneToX(currentLane);

        transform.position = Vector3.Lerp(transform.position, targetPos, laneChangeSpeed * Time.deltaTime);
    }

    private void ChangeLane(int direction)
    {
        currentLane = Mathf.Clamp(currentLane + direction, 0, 2);
    }

    private float LaneToX(int laneIndex)
    {
     
        return (laneIndex - 1) * laneOffset;
    }
    public void SetAlive(bool alive)
    {
        isAlive = alive;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            SetAlive(false);

            if (GameManager.instance != null)
                GameManager.instance.GameOver();
        }
    }


}
