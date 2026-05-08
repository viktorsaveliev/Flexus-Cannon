
namespace FlexusCannon.WeaponSystem
{
    public readonly struct WeaponUtilityEvent
    {
        public IWeapon Weapon { get; }
        public UtilityContext Context { get; }

        public WeaponUtilityEvent(IWeapon weapon, UtilityContext context)
        {
            Weapon = weapon;
            Context = context;
        }
    }
}
