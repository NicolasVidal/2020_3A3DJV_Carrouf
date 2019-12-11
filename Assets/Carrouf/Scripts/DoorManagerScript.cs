using System;
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

        private Action<Collider> increaseTriggerAndCheckOpenParameter;
        private Action<Collider> decreaseTriggerAndCheckOpenParameter;

        private int triggerCount;
        
        private void Awake()
        {
            increaseTriggerAndCheckOpenParameter = _ =>
            {
                triggerCount++;

                if (triggerCount == 1)
                {
                    doorAnimator.SetBool(IsOpened, true);
                }
            };
            decreaseTriggerAndCheckOpenParameter = _ =>
            {
                triggerCount--;

                if (triggerCount == 0)
                {
                    doorAnimator.SetBool(IsOpened, false);
                }
            };
            
            doorDetectionZoneTriggerDispatcher.TriggerEntered += increaseTriggerAndCheckOpenParameter;
            doorDetectionZoneTriggerDispatcher.TriggerExited += decreaseTriggerAndCheckOpenParameter;
        }

        private void OnDestroy()
        {
            doorDetectionZoneTriggerDispatcher.TriggerEntered -= increaseTriggerAndCheckOpenParameter;
            doorDetectionZoneTriggerDispatcher.TriggerEntered -= decreaseTriggerAndCheckOpenParameter;
        }
    }
}