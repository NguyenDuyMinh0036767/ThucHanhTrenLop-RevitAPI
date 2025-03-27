using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using System.Windows.Forms;
using Autodesk.Revit.UI.Selection;
using System.Windows.Forms.VisualStyles;
namespace _27_03_2025
{
    namespace A002_SelectElement
    {
        [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
        public class A002_SelectElement : IExternalCommand
        {
            public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
            {
                UIDocument uidoc = commandData.Application.ActiveUIDocument;
                ICollection<ElementId> selectElements = uidoc.Selection.GetElementIds();
                int totalCount = selectElements.Count;
                MessageBox.Show("Ban da chon " + totalCount.ToString() + " elements");
                //Phat trien code
                string IdList = "Danh sach ID cua doi tuong:\n";
                foreach (ElementId e1 in selectElements)
                {
                    IdList = IdList + e1.ToString() + "\n";
                }
                MessageBox.Show(IdList);
                
                XYZ point1 = uidoc.Selection.PickPoint();
                XYZ point2 = uidoc.Selection.PickPoint();
                XYZ point3 = uidoc.Selection.PickPoint();
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(point1.ToString());
                sb.AppendLine(point2.ToString());
                sb.AppendLine(point3.ToString());
                MessageBox.Show("Bạn đã lựa chọn các điểm points: \n" + sb.ToString());
                
                IList<Reference> referenceCollection = uidoc.Selection.PickObjects(ObjectType.Edge);
                MessageBox.Show("You have selected total " + referenceCollection.Count.ToString() + " Edges.");
                return Result.Succeeded;
            }
            
        }
    }
}
