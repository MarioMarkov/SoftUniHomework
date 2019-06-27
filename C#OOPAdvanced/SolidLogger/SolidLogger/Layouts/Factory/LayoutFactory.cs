using SolidLogger.Layouts.Contracts;
using SolidLogger.Layouts.Factory.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolidLogger.Layouts.Factory
{
    public class LayoutFactory : ILayoutFactory
    {
        public ILayout CreateLayout(string type)
        {
            string typeAsLower = type.ToLower();
            switch (typeAsLower)
            {
                case "simplelayout": return new SimpleLayout();

                case "xmllayout": return new XmlLayout();
                default:
                    throw new ArgumentException("Invalid layout type!");
                    break;
            }
        }
    }
}
