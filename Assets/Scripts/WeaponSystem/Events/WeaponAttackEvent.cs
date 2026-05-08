
namespace FlexusCannon.WeaponSystem
{
    public readonly struct WeaponAttackEvent
    {
        public IWeapon Weapon { get; }
        public AttackContext Context { get; }

        public WeaponAttackEvent(IWeapon weapon, AttackContext context)
        {
            Weapon = weapon;
            Context = context;
        }
    }
}
