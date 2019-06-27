using SolidLogger.Layouts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolidLogger.Layouts.Factory.Contracts
{
    public interface ILayoutFactory
    {
        ILayout CreateLayout(string type);
    }
}
