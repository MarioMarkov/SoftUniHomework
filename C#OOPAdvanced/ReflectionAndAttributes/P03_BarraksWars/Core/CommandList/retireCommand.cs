using System;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Contracts;

namespace P03_BarraksWars.Core.CommandList
{
    public class retireCommand : Command
    {
        public retireCommand(string[] data, IRepository repository, IUnitFactory unitFactory) : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            string unitType = Data[1];
            
            string output = this.Repository.RemoveUnit(unitType);
            return output;
        }
    }
}
