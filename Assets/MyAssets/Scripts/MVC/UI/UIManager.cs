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

        public void PopUpAchievement(BulletAchievementType achievementType)
        {
            bulletAchivementPanel.SetActive(true);
            bulletAchiementText.text = "Achievement : " + achievementType;
        }

    }
}