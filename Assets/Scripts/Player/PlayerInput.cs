using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Deterministic;
using Quantum;

namespace SimpleFPS
{
	/// <summary>
	/// Handles player input.
	/// </summary>
	[DefaultExecutionOrder(-10)]
	public sealed class PlayerInput : MonoBehaviour
	{
		public static float LookSensitivity;

		[SerializeField]
		private QuantumEntityViewUpdater _entityViewUpdater;

		private Quantum.Input _accumulatedInput;
		private bool          _resetAccumulatedInput;
		private int           _lastAccumulateFrame;

		private void OnEnable()
		{
			QuantumCallback.Subscribe(this, (CallbackPollInput callback) => PollInput(callback));
		}

		private void Update()
		{
			AccumulateInput();
		}

		private void AccumulateInput()
		{
			if (_lastAccumulateFrame == Time.frameCount)
				return;

			_lastAccumulateFrame = Time.frameCount;

			if (_resetAccumulatedInput)
			{
				_resetAccumulatedInput = false;
				_accumulatedInput = default;
			}

			ProcessStandaloneInput();
		}

		private void ProcessStandaloneInput()
		{
			// Enter key is used for locking/unlocking cursor in game view.
			Keyboard keyboard = Keyboard.current;
			if (keyboard != null && (keyboard.enterKey.wasPressedThisFrame || keyboard.numpadEnterKey.wasPressedThisFrame))
			{
				if (Cursor.lockState == CursorLockMode.Locked)
				{
					Cursor.lockState = CursorLockMode.None;
					Cursor.visible = true;
				}
				else
				{
					Cursor.lockState = CursorLockMode.Locked;
					Cursor.visible = false;
				}
			}

			// Accumulate input only if the cursor is locked.
			if (Cursor.lockState != CursorLockMode.Locked)
				return;

			Mouse mouse = Mouse.current;
			if (mouse != null)
			{
				Vector2 mouseDelta = mouse.delta.ReadValue();

				Vector2 lookRotationDelta = new Vector2(-mouseDelta.y, mouseDelta.x);
				lookRotationDelta *= LookSensitivity / 60f;
				_accumulatedInput.LookRotationDelta += lookRotationDelta.ToFPVector2();

				_accumulatedInput.Fire |= mouse.leftButton.isPressed;
			}

			if (keyboard != null)
			{
				Vector2 moveDirection = Vector2.zero;

				if (keyboard.wKey.isPressed) { moveDirection += Vector2.up;    }
				if (keyboard.sKey.isPressed) { moveDirection += Vector2.down;  }
				if (keyboard.aKey.isPressed) { moveDirection += Vector2.left;  }
				if (keyboard.dKey.isPressed) { moveDirection += Vector2.right; }

				_accumulatedInput.MoveDirection = moveDirection.normalized.ToFPVector2();

				_accumulatedInput.Jump    |= keyboard.spaceKey.isPressed;
				_accumulatedInput.Reload  |= keyboard.rKey.isPressed;
				_accumulatedInput.Spray   |= keyboard.fKey.isPressed;

				for (int i = (int)Key.Digit1; i <= (int)Key.Digit9; i++)
				{
					if (keyboard[(Key)i].isPressed)
					{
						_accumulatedInput.Weapon = (byte)(i - Key.Digit1 + 1);
						break;
					}
				}
			}
		}

		public void PollInput(CallbackPollInput callback)
		{
			AccumulateInput();

			_accumulatedInput.InterpolationOffset = (byte)Mathf.Clamp(callback.Frame - _entityViewUpdater.SnapshotInterpolation.CurrentFrom, 0, 255);
			_accumulatedInput.InterpolationAlpha  = _entityViewUpdater.SnapshotInterpolation.Alpha.ToFP();

			callback.SetInput(_accumulatedInput, DeterministicInputFlags.Repeatable);

			_resetAccumulatedInput = true;
			_accumulatedInput.LookRotationDelta = default;
		}
	}
}
