using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float rotateSpeed;
    public float burstSpeed;
    public InputActionAsset inputActions;

    private CharacterController m_characterController;
    public Transform cameraTransform;
    private InputAction m_moveAction;
    private InputAction m_lookAction;
    private InputAction m_attackAction; // Добавляем действие атаки
    private Vector3 m_cameraOffset;
    private Vector3 m_Rotation;
    private void Awake()
    {
        m_characterController = GetComponent<CharacterController>();
    }

    void Start()
    {
        m_moveAction = inputActions.FindAction("Player/Move");
        m_lookAction = inputActions.FindAction("Player/Look");
        m_attackAction = inputActions.FindAction("Player/Attack"); // Получаем действие атаки

        m_moveAction.Enable();
        m_lookAction.Enable();
        m_attackAction.Enable();

        m_cameraOffset = cameraTransform.position - transform.position;
    }

    public void Update()
    {
        Vector2 move = m_moveAction.ReadValue<Vector2>();
        Vector2 look = m_lookAction.ReadValue<Vector2>();
        Move(move);
        Look(look);
    }

    private void Move(Vector2 direction)
    {
        if (direction.sqrMagnitude < 0.01)
            return;

        var scaledMoveSpeed = moveSpeed * Time.deltaTime;
        var move = Quaternion.Euler(0, transform.eulerAngles.y, 0) * new Vector3(direction.x, 0, direction.y);
        transform.position += move * scaledMoveSpeed;
    }

    private void Look(Vector2 rotate)
    {
        if (rotate.sqrMagnitude < 0.01)
            return;

        var scaledRotateSpeed = rotateSpeed * Time.deltaTime;
        m_Rotation.y += rotate.x * scaledRotateSpeed;
        m_Rotation.x = Mathf.Clamp(m_Rotation.x - rotate.y * scaledRotateSpeed, 0, 0);
        transform.localEulerAngles = m_Rotation;
    }

    private void LateUpdate()
    {
        cameraTransform.position = transform.position + m_cameraOffset;
    }
}