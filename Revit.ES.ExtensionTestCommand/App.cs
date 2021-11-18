#region Namespaces

using Autodesk.Revit.UI;

#endregion

namespace Revit.ES.Extension.Demo
{
    class App : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication a)
        {
            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }
    }

    public static class Utils
    {
        public const string specTypeIdPrefix = "autodesk.spec.aec";
        public const string specTypeIdSuffix = "-2.0.0";
    }
}
