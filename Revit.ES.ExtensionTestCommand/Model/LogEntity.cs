using Revit.ES.Extension.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revit.ES.Extension.Demo.Model
{
    [Schema("B2B69AC9-2C51-46C8-A3A0-51A6D5E9C320", "UserHistory",
        Documentation = "The Information Data Of User")]
    public class LogEntity : IRevitEntity
    {
        [Field]
        public List<UserHistory> Databases { get; set; }
    }
}
