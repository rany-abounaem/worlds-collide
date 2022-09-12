using UnityEngine.SceneManagement;

namespace WorldsCollide.UI
{
    public class PlayButtonAction : CustomButtonAction
    {
        public override void Trigger()
        {
            SceneManager.LoadScene(2);
        }
    }

}
