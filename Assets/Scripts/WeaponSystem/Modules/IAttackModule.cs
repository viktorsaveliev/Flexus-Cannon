namespace FlexusCannon.WeaponSystem.ModuleSystem
{
    public interface IAttackModule
    {
        public bool TryAttack(AttackContext context);
    }
}
