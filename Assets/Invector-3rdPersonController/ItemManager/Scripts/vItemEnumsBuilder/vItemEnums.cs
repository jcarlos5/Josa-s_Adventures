using System.ComponentModel;
namespace Invector.vItemManager {
     public enum vItemType {
       [Description("Alimentos")] Consumable=0,
       [Description("Melee")] MeleeWeapon=1,
       [Description("Shooter")] ShooterWeapon=2,
       [Description("(VALUE)")] Ammo=3,
       [Description("")] Archery=4,
       [Description("")] Builder=5,
       [Description("")] Defense=6,
       [Description("Coleccionables")] Collectable=7
     }
     public enum vItemAttributes {
       [Description("Poción de salud")] Health=0,
       [Description("")] Stamina=1,
       [Description("<i>Damage</i> : <color=red>(VALUE)</color>")] Damage=2,
       [Description("")] StaminaCost=3,
       [Description("")] DefenseRate=4,
       [Description("")] DefenseRange=5,
       [Description("(VALUE)")] AmmoCount=6,
       [Description("Poción de salud máxima")] MaxHealth=7,
       [Description("")] MaxStamina=8,
       [Description("(VALUE)")] SecundaryAmmoCount=9,
       [Description("")] SecundaryDamage=10,
       [Description("Inmortalidad")] Inmortalidad=11,
       [Description("Monedas")] Money=12,
       [Description("Pieza de llave")] PieceKey=13
     }
}
