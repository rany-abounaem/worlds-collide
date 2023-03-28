using UnityEngine;
using UnityEngine.UI;

namespace WorldsCollide.UI
{
    [System.Serializable]
    public class CustomButton : MonoBehaviour
    {
        Button _button;
        [SerializeField] CustomButtonAction _action;


        private void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(HandleButtonClicked);
        }

        private void HandleButtonClicked()
        {
            _action.Trigger();
        }
    }
}
