using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private KeyCode moveUp = KeyCode.W;
    [SerializeField] private KeyCode moveRight = KeyCode.D;
    [SerializeField] private KeyCode moveDown = KeyCode.S;
    [SerializeField] private KeyCode moveLeft = KeyCode.A;
    [SerializeField] private float movSpeed = 2.0f;
    public float MovSpeed
    {
        get { return movSpeed; }
        set { movSpeed = value; }
    }

    [Header("Rotation")]
    [SerializeField] private KeyCode rotateRight = KeyCode.E;
    [SerializeField] private KeyCode rotateLeft = KeyCode.Q;
    [SerializeField] private int rotationSpeed = 10;

    [Header("Color")]
    [SerializeField] private KeyCode changeColor = KeyCode.R;
    [SerializeField] private SpriteRenderer spriteRenderer;
    void Start()
    {

    }

    private void Update()

    {
        //Movement
        if (Input.GetKey(moveUp))
        {
            transform.position += new Vector3(0, movSpeed * Time.deltaTime);
        }
        if (Input.GetKey(moveRight))
        {
            transform.position += new Vector3(movSpeed * Time.deltaTime, 0);

        }
        if (Input.GetKey(moveDown))
        {
            transform.position += new Vector3(0, -movSpeed * Time.deltaTime);

        }
        if (Input.GetKey(moveLeft))
        {
            transform.position += new Vector3(-movSpeed * Time.deltaTime, 0);
        }


        //Color
        if (Input.GetKeyUp(changeColor))
        {
            float r = Random.value;
            float g = Random.value;
            float b = Random.value;

            spriteRenderer.color = new Color(r, g, b);

        }



        //Rotation
        if (Input.GetKeyDown(rotateRight))
        {
            transform.Rotate(Vector3.forward * rotationSpeed);
        }

        if (Input.GetKeyDown(rotateLeft))
        {
            transform.Rotate(Vector3.forward * -rotationSpeed);
        }



    }
}
