using UnityEngine;

namespace Code.Configs
{
    [CreateAssetMenu(order = 5, fileName = "BulletCfg", menuName = "Config/BulletCfg")]
    public class BulletCfg:ScriptableObject
    {
        [Tooltip("Время перезарядки, с")]public float RechargeTime;
        public AttackStrength AttackStrength;
        public float LowAttack;
        public float MiddleAttack;
        public float HighAttack;
        public GameObject Explosion;
    }

    public enum AttackStrength
    {
        Low = 0,
        Middle = 1,
        High = 2
    }
}