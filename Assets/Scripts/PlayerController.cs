using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public InputAction moveAction;
    public InputAction shootAction;
    public float xRange = 10;

    public GameObject FoodPrefab;

    public float fireRate = 1f;
    public float nextFireTime = 0f;

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        shootAction = InputSystem.actions.FindAction("Shoot");
    }
    private void OnEnable()
    {
        shootAction.Enable();
    }
    private void OnDisable()
    {
        shootAction.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        var shootInput = shootAction.ReadValue<float>();

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

        if (shootInput > 0 && Time.time > nextFireTime)
        {
            Instantiate(FoodPrefab, transform.position, Quaternion.identity);
            nextFireTime = Time.time + fireRate;
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
