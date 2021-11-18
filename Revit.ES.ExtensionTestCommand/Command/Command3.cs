using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.ExtensibleStorage;
using Autodesk.Revit.UI;
using Revit.ES.Extension.Demo.Model;
using Revit.ES.Extension.ElementExtensions;


namespace Revit.ES.Extension.Demo.Command
{
    [Transaction(TransactionMode.Manual)]
    public class SaveHistory : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Autodesk.Revit.ApplicationServices.Application App
                = commandData.Application.Application;
            UIDocument UiDoc = commandData.Application.ActiveUIDocument;
            Document Doc = UiDoc.Document;
            using (Transaction tran = new Transaction(Doc))
            {
                tran.Start("Change");
                GetlistSchema(Doc);
                //GetSchema(Doc);
                //SetSchema(Doc);
                tran.Commit();

            }
            
            return Result.Succeeded;
        }

        void SetSchema(Document doc)
        {
            ProjectInfo project = doc.ProjectInformation;

            LogEntity logEntity = project.GetEntity<LogEntity>();
            if (logEntity == null)
            {
                logEntity = new LogEntity();
            }

            if (logEntity.Databases == null) logEntity.Databases = new List<UserHistory>();
            UserHistory userHistory = new UserHistory()
            {
                Category = project.Category.Name,
                Id = project.Id.ToString(),
                LastTransaction = "Yes",
                MachineName = Environment.UserName,
                Name = project.Name,
                Operation = "Change",
                SaveTimed = DateTime.Today.ToString(),
                UniqueId = project.UniqueId,

            };

            logEntity.Databases.Add(userHistory);
            project.SetEntity(logEntity);
            //Schema schema = Schema.Lookup(new Guid("13D10290-F709-49FD-BA30-A6ECA53297BE"));
            //Schema.EraseSchemaAndAllEntities(schema,true);
            MessageBox.Show("Set");
        }

        void GetSchema(Document doc)
        {
            ProjectInfo projectInfo = doc.ProjectInformation;
            //Schema schema = Schema.Lookup(new Guid("B2B69AC9-2C51-46C8-A3A0-51A6D5E9C320"));
            LogEntity logEntity = projectInfo.GetEntity<LogEntity>();
            MessageBox.Show(logEntity.Databases.Count.ToString());
            string path = @"C:\Users\Chuong.Ho\Downloads\test.txt";
            using (StreamWriter writer = new StreamWriter(path, true)) //// true to append data to the file
            {
                foreach (UserHistory userHistory in logEntity.Databases)
                {
                    writer.WriteLine(userHistory.Category);
                    writer.WriteLine(userHistory.Name);
                }
            }
            //StringBuilder st = new StringBuilder();
            //foreach (UserHistory userHistory in logEntity.Databases)
            //{
            //    st.AppendLine(userHistory.Category);
            //    st.AppendLine(userHistory.Id);
            //    st.AppendLine(userHistory.Name);
            //    st.AppendLine(userHistory.MachineName);
            //    st.AppendLine(userHistory.UniqueId);
            //    st.AppendLine(userHistory.SaveTimed);

            //}
            //MessageBox.Show(st.ToString());
        }

        void GetlistSchema(Document doc)
        {
            IList<Schema> schemas = Schema.ListSchemas();
            StringBuilder st = new StringBuilder();
            foreach (Schema schema in schemas)
            {
                if (schema.SchemaName=="UserHistory")
                {
                    doc.EraseSchemaAndAllEntities(schema);
                    MessageBox.Show("Im here");
                }
                st.AppendLine(schema.SchemaName.ToString());
            }
            
            System.Windows.Forms.MessageBox.Show(st.ToString());
        }
    }
}
