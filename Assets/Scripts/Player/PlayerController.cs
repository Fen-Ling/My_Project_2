using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float rotateSpeed;
    public InputActionAsset inputActions;
    private InputAction m_lookAction;
    private Vector3 m_Rotation;
    private bool isPlayerInRange = false;
    private Vector3 savedPosition;

    private void Awake()
    {
        savedPosition = PlayerDataManager.playerData.position;
        TeleportPlayer();
        m_lookAction = inputActions.FindAction("Player/Look");
        m_lookAction.Enable();
    }

    public void Update()
    {
        Vector2 look = m_lookAction.ReadValue<Vector2>();
        Look(look);
    }

    private void Look(Vector2 rotate)
    {
        if (!isPlayerInRange)
        {
            if (rotate.sqrMagnitude < 0.01)
                return;

            var scaledRotateSpeed = rotateSpeed * Time.deltaTime;
            m_Rotation.y += rotate.x * scaledRotateSpeed;
            m_Rotation.x = Mathf.Clamp(m_Rotation.x - rotate.y * scaledRotateSpeed, 0, 0);
            transform.localEulerAngles = m_Rotation;
        }
    }

    public void SetPlayerInRange(bool value)
    {
        isPlayerInRange = value;
    }

    private void TeleportPlayer()
    {
        gameObject.GetComponent<CharacterController>().enabled = false;
        transform.position = savedPosition;
        gameObject.GetComponent<CharacterController>().enabled = true;
    }
}