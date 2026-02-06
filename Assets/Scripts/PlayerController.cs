using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public InputAction moveAction;
    public InputAction shootAction;
    public float xRange = 10;

    public GameObject FoodPrefab;

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        shootAction = InputSystem.actions.FindAction("Shoot");
    }

    // Update is called once per frame
    void Update()
    {

        var hInput = moveAction.ReadValue<Vector2>().x;
        //if (transform.position.x < 10 || transform.position.x > -10)
        //{
        transform.Translate(hInput * speed * Time.deltaTime * Vector3.right);
        //}
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (shootAction.triggered)
        {
            Instantiate(FoodPrefab, transform.position, Quaternion.identity);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(transform.position, 1);
        //Gizmos.color = Color.green;
        //Gizmos.DrawLine(transform.position, Camera.main.transform.position);
        Gizmos.DrawLine(new Vector3(-xRange,transform.position.y,transform.position.z),new Vector3(xRange,transform.position.y,transform.position.z));
    }
}
