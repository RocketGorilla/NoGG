using UnityEngine;
using UnityEngine.XR;
using GorillaLocomotion;

namespace GravityDisabler.Components
{
    public class GravityLoopBehaviour : MonoBehaviour
    {
        private bool _isGravityDisabled = false;
        private bool _wasSecondaryButtonPressed = false;

        private void Update()
        {
            bool isPressed = false;
            if (ControllerInputPoller.instance != null)
            {
                isPressed = ControllerInputPoller.instance.rightControllerSecondaryButton;
            }

            if (isPressed && !_wasSecondaryButtonPressed)
            {
                ToggleGravity();
            }

            _wasSecondaryButtonPressed = isPressed;
        }

        private void ToggleGravity()
        {
            _isGravityDisabled = !_isGravityDisabled;

            if (GTPlayer.Instance != null)
            {
                if (_isGravityDisabled)
                {
                    GTPlayer.Instance.SetGravityOverride(this, ZeroGravityOverride);
                }
                else
                {
                    GTPlayer.Instance.UnsetGravityOverride(this);
                }
            }
        }

        private void ZeroGravityOverride(GTPlayer player)
        {
            if (player != null)
            {
                player.AddForce(Vector3.zero, ForceMode.Acceleration);
            }
        }

        private void OnDisable()
        {
            if (_isGravityDisabled && GTPlayer.Instance != null)
            {
                GTPlayer.Instance.UnsetGravityOverride(this);
                _isGravityDisabled = false;
            }
        }
    }
}
