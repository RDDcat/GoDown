using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Go : MonoBehaviour
{
    public Canvas upgradeCanvas;
    public Canvas feverCanvas;

    public UpgradeButton upgradeButton;

    private void Start()
    {
        upgradeCanvas.enabled = true;
        feverCanvas.enabled = true;

        upgradeButton = FindObjectOfType<UpgradeButton>();
    }

    public void ExitStore()
    {
        upgradeButton.ResetMain();


        AccountManager.instance.SaveAccount();

        SceneManager.UnloadSceneAsync("4STORE");


        // 클릭사운드
        SoundManager.instance.sfxPlay(SoundManager.Sfx.Click);
    }

    
}
