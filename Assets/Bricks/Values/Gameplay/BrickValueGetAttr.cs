namespace Grimmz
{
    public class BrickValueGetAttr : BrickValue
    {
        private Unit unit;

        public override int Return => unit.GetAttr("attrName");
    }
}

