using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // حرکت رو به جلو
    [Header("Forward Movement")]
    public float forwardSpeed = 8f;

    // لاین‌ها
    [Header("Lane Movement")]
    public float laneOffset = 2.5f;     // فاصله بین لاین‌ها
    public float laneChangeSpeed = 12f; // سرعت رفتن به لاین هدف

    private int currentLane = 1; // 0=چپ، 1=وسط، 2=راست
    private bool isAlive = true;

    void Update()
    {
        if (!isAlive) return;

        // Input: A/D یا Arrow
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            ChangeLane(-1);

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            ChangeLane(+1);

        // حرکت رو به جلو (ثابت)
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime, Space.World);

        // حرکت نرم به لاین هدف
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
        // 0-> -offset, 1->0, 2-> +offset
        return (laneIndex - 1) * laneOffset;
    }

    // این را بعدا برای GameOver استفاده می‌کنیم
    public void SetAlive(bool alive)
    {
        isAlive = alive;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            // جلوگیری از چند بار تریگر شدن
            SetAlive(false);

            // صدا زدن گیم اور
            if (GameManager.instance != null)
                GameManager.instance.GameOver();
        }
    }


}
