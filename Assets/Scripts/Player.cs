using UnityEngine;

public class Player : MonoBehaviour
{
    public float speedBtn;
    public float speedTouch;
    public float speedAcc;
    public float xBorders;
    public float projectileSpeed;
    public GameType gType;

    public GameObject missile;

    private Rigidbody2D rb2d;

    private float move;
    public int missiles;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        switch (gType)
        {
            //Buttons
            case GameType.Buttons:
                float xPos = transform.position.x + (move * speedBtn);
                //float xPos = transform.position.x + (Input.GetAxis("Horizontal") * speedBtn * 1.5f);
                Vector2 playerPos = new Vector2(Mathf.Clamp(xPos, xBorders * -1, xBorders), -4f);
                transform.position = playerPos;
                break;

            //Touch
            case GameType.Touch:
                if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    // Get movement of the finger since last frame
                    Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

                    // Move object across X plane
                    transform.Translate(touchDeltaPosition.x * speedTouch, 0, 0);
                }

                rb2d.position = new Vector2(Mathf.Clamp(rb2d.position.x, xBorders * -1, xBorders), -4f);
                break;

            //Accelerometer
            case GameType.Accelerometer:
                float moveHorizontal = Input.acceleration.x * 2f;

                Vector2 movement = new Vector2(moveHorizontal, 0);

                rb2d.AddForce(movement * speedAcc * -1);

                rb2d.position = new Vector2(Mathf.Clamp(rb2d.position.x, xBorders * -1, xBorders), -4f);
                break;

            case GameType.Keyboard:

                break;
        }
    }

    public void Move(int x)
    {
        move = x;
    }

    public void Stop()
    {
        move = 0;
    }

    public void Shoot()
    {
        if (missiles <= 0) return;

        GameObject miss = Instantiate(missile, transform.position, Quaternion.identity);

        miss.GetComponent<Rigidbody2D>().AddForce(Vector2.up * projectileSpeed);

        Destroy(miss, 5f);
        missiles--;
    }

    public void AddMissile(int missile)
    {
        missiles += missile;
    }
}

public enum GameType
{
    Buttons,
    Touch,
    Accelerometer,
    Keyboard,
}