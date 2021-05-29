namespace Grimmz
{
    public class Unit : IHaveHP
    {
        public int CurrentHP { get; }

        public int MaxHP { get; }

        public void TakeDamage(int amount)
        {

        }

        public void Heal(int amount)
        {
            
        }

        public int GetAttr(string attrName)
        {
            return 69;
        }

        public void SetAttr(string attrName, int value)
        {

        }

        public void ChangeAttr(string attrName, int byValue)
        {

        }
    }
}
