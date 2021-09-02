using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace BattleTank
{
    public class UIManager : MonoSingletonGeneric<UIManager>
    {
        public GameObject bulletAchivementPanel;
        public TextMeshProUGUI bulletAchiementText;

        async public void PopUpAchievement(string achievement)
        {
            bulletAchivementPanel.SetActive(true);
            bulletAchiementText.text = "Achievement Unlocked : " + achievement;
            await new WaitForSeconds(3f);
            bulletAchivementPanel.SetActive(false);
        }
    }
}