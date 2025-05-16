using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNavigation : MonoBehaviour
{

    public void SwitchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName); //can be used for loading multiple scenes
        
    }



}
