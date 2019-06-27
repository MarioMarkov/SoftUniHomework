namespace _03BarracksFactory.Core.Factories
{
    using System;
    using System.Reflection;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            //TODO: implement for Problem 3
            Type type = Type.GetType("_03BarracksFactory.Models.Units."+unitType);
            IUnit unit = (IUnit)Activator.CreateInstance(type,true );
            return unit;
        }
    }
}
