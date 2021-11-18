using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Revit.ES.Extension.Attributes;

namespace Revit.ES.Extension.Demo.Model
{
    [Schema("93CC69FC-AB6F-451A-B075-A5D9467569C2",
        "SimpleSchema")]
    public class UserHistory : IRevitEntity
    {

        [Field]
        public string Category { get; set; }

        [Field]
        public string Name { get; set; }

        [Field]
        public string Id { get; set; }

        [Field]
        public string UniqueId { get; set; }

        [Field]
        public string UserName { get; set; }

        [Field]
        public string Operation { get; set; }

        [Field]
        public string LastTransaction { get; set; }

        [Field]
        public string SaveTimed { get; set; }

        [Field]
        public string MachineName { get; set; }

    }
}
