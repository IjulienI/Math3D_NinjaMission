using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CharacterMovemebt : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float camSpeed;
    private Rigidbody rb;
    private Vector2 input;
    private Vector2 mouseInput;
    private bool canBackStab;
    public static CharacterMovemebt instance;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        MovementUpdate();
        RotationFixedUpdate();
    }
    private void MovementUpdate()
    {
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Vector3 moveDirection = transform.forward * input.y + transform.right * input.x;
        transform.position = transform.position + moveDirection * speed * Time.deltaTime;
    }

    private void RotationFixedUpdate()
    {
        mouseInput += new Vector2(Input.GetAxis("Mouse X") * camSpeed * Time.fixedDeltaTime, Input.GetAxis("Mouse Y") * camSpeed * Time.fixedDeltaTime);
        transform.rotation = Quaternion.Euler(0, mouseInput.x, 0);
    }
    public void SetCanBackStab(bool state)
    {
        canBackStab = state;
    }
    public bool GetCanBackstab()
    {
        return canBackStab;
    }
}
