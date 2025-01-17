using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class HotKeyController : MonoBehaviour
	{
		[SerializeField] private InputActionProperty m_hotkey;
		[SerializeField] private UnityEvent m_onPerformed;

		private void OnEnable()
		{
			m_hotkey.action.performed += OnActionPerformed;
			
			if (m_hotkey.reference == null)
			{
				m_hotkey.action.Enable();
			}
		}

		private void OnDisable()
		{
			if (m_hotkey.reference == null)
			{
				m_hotkey.action.Disable();
			}

			m_hotkey.action.performed -= OnActionPerformed;
		}
		
		private void OnActionPerformed(InputAction.CallbackContext context)
		{
			m_onPerformed.Invoke();
		}
	}