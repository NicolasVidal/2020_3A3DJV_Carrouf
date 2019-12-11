using UnityEngine;

namespace Carrouf.Scripts
{
    public class DoorManagerScript : MonoBehaviour
    {
        [SerializeField]
        private TriggerDispatcherScript doorDetectionZoneTriggerDispatcher;

        [SerializeField]
        private Animator doorAnimator;

        private static readonly int IsOpened = Animator.StringToHash("IsOpened");

        private void Awake()
        {
            doorDetectionZoneTriggerDispatcher.TriggerEntered += _ => doorAnimator.SetBool(IsOpened, true);
            doorDetectionZoneTriggerDispatcher.TriggerExited += _ => doorAnimator.SetBool(IsOpened, false);
        }
    }
}