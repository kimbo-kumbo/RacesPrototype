using System.Threading.Tasks;
using UnityEngine;

namespace RacePrototype
{
    public class FinishTrigger : MonoBehaviour
    {
        private Statistics_Controller _statisticsController;
        private Timer _timer;
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Body_Marker>() /*|| other.GetComponent<NewPlayer>() */is null)
                return;

            SaveStatistics();

            OnEnableStaticsPanel();
            Debug.Log("Finish");
        }

        private void SaveStatistics()
        {
            Record newRecord;
            newRecord.name = "Test";
            newRecord.time = _timer.ConvertTimeElapsedToFloat();
            _statisticsController.SaveRecord(newRecord);
        }

        private void Start()
        {
            _statisticsController = FindObjectOfType<Statistics_Controller>();
            _timer = FindObjectOfType<Timer>();
        }

        private async void OnEnableStaticsPanel()
        {
            await Task.Delay(2000);
            _statisticsController.gameObject.SetActive(true);            
        }
    }
}
