﻿using UnityEngine;

namespace KID
{
    /// <summary>
    /// 技能資料
    /// </summary>
    [CreateAssetMenu(menuName = "KID/Data Skill", fileName = "Data Skill")]
    public class DataSkill : ScriptableObject
    {
        [Header("技能名稱")]
        public string skillName;
        [Header("技能圖片")]
        public Sprite skillPicture;
        [Header("技能描述"), TextArea(3, 5)]
        public string skillDescription;
        [Header("技能等級"), Range(1, 5)]
        public int lv = 1;
        [Header("技能數值")]
        public float[] skillValues;
    }
}