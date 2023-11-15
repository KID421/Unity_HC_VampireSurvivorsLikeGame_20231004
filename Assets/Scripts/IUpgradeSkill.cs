namespace KID
{
    /// <summary>
    /// 升級技能
    /// </summary>
    public interface IUpgradeSkill
    {
        /// <summary>
        /// 升級技能
        /// </summary>
        public void UpgradeSkill();

        /// <summary>
        /// 還原到等級 1
        /// </summary>
        public void ResetToLv1();
    }
}