using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    
    [SerializeField] float yValue = 0f;
    [SerializeField] float powerRadius = 10f;
    [SerializeField] float powerForce = 50f;
    [SerializeField] bool isAttracting = true;
    private PlayerInput playerInput;
    private InputAction moveAction;
    private Vector2 inputs;
    private Vector3 movement;
    [SerializeField] private float speedMovement = 14f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];
    }

    void OnAttack(InputValue input)
    {
          isAttracting = !isAttracting;
    }

    void OnJump(InputValue value)
    {
     
         Collider[] colliders = Physics.OverlapSphere(transform.position, powerRadius);
        foreach (Collider col in colliders)
        {
            Rigidbody rb = col.GetComponent<Rigidbody>();
            if (rb != null && rb.gameObject != gameObject)
            {
                
                Vector3 direction = isAttracting 
                    ? (transform.position - rb.position).normalized     // atraer
                    : (rb.position - transform.position).normalized;     // repeler

                rb.AddForce(direction * powerForce, ForceMode.Force);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
       MovePlayer();
    }

    void MovePlayer(){
        if (moveAction == null) return;

        inputs = moveAction.ReadValue<Vector2>();
        if (inputs.sqrMagnitude > 0.01f)
        {
            
            if (inputs.magnitude > 1f) inputs.Normalize();

            movement = new Vector3(inputs.x, yValue, inputs.y) * speedMovement * Time.deltaTime;

            transform.Translate(movement, Space.World);
        }
    }
}
