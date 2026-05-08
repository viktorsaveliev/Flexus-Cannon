
namespace FlexusCannon.Additional
{
    public interface ITickMaster
    {
        public void AddListener(ITickable listener);
        public void RemoveListener(ITickable listener);
    }
}
