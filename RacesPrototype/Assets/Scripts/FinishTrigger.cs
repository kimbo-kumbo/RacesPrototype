using UnityEngine;

namespace RacePrototype
{
    public class FinishTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<CarComponent>() /*|| other.GetComponent<NewPlayer>() */is null)
                return;

            Debug.Log("Finish");
        }
    }
}
