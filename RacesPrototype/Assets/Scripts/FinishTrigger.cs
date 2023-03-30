using System.Threading.Tasks;
using UnityEngine;

namespace RacePrototype
{
    public class FinishTrigger : MonoBehaviour
    {
        [SerializeField] private Statistics_Controller statisticsController;
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Body_Marker>() /*|| other.GetComponent<NewPlayer>() */is null)
                return;
            OnEnableStaticsPanel();
            Debug.Log("Finish");
        }


        private async void OnEnableStaticsPanel()
        {
            await Task.Delay(2000);
            statisticsController.gameObject.SetActive(true);            
        }
    }
}
