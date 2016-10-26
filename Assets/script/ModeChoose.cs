using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
/// <summary>
/// 模式选择
/// </summary>
public class ModeChoose : MonoBehaviour {

    /// <summary>
    /// 无尽模式
    /// </summary>
    public void SelectInfiniteMode()
    {
        PlayerPrefs.SetInt(Util.GAME_TYPE, Util.GAME_TYPE_INFINTE);
        PlayerPrefs.SetInt(Util.INFINETE_LEVEL, Util.INFINETE_DEFULT_LEVEL);
        PlayerPrefs.SetInt(Util.INFINETE_N, Util.INFINETE_DEFULT_N);
        SceneManager.LoadSceneAsync(Util.SCENES_GAME);
    }

    /// <summary>
    /// 冒险模式
    /// </summary>
    public void SelectAdventureMode()
    {
        PlayerPrefs.SetInt(Util.GAME_TYPE, Util.GAME_TYPE_ADV);
        SceneManager.LoadSceneAsync(Util.SCENES_GAME);        
    }


    
}
