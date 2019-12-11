using System;
using UnityEngine;

namespace Carrouf.Scripts
{
    public class BallDestroyerManagerScript : MonoBehaviour
    {
        [SerializeField]
        private TriggerDispatcherScript triggerDispatcherScript;

        private Action<Collider> destroyOnTriggerMethod = delegate(Collider collider) { Destroy(collider.gameObject); };

        private void Awake()
        {
            triggerDispatcherScript.TriggerEntered += destroyOnTriggerMethod;
        }

        private void OnDestroy()
        {
            triggerDispatcherScript.TriggerExited -= destroyOnTriggerMethod;
        }
    }
}