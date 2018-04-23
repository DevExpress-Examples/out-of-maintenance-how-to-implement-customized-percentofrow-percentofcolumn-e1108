using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DevExpress.Web.ASPxPivotGrid;

namespace WebApplication4
{
    public partial class _Default : System.Web.UI.Page
    {
        string mode;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ASPxRadioButtonList1.SelectedItem != null)
            {
                mode = Convert.ToString(ASPxRadioButtonList1.SelectedItem.Value);
                ASPxPivotGrid1.DataBind();
            }
        }

        protected void ASPxPivotGrid1_CustomCellDisplayText(object sender, DevExpress.Web.ASPxPivotGrid.PivotCellDisplayTextEventArgs e)
        {
            if(e.DataField.FieldName != "Custom") return;
            bool percentOfRow = mode == "PercentOfRow";
            ASPxPivotGrid pivot = sender as ASPxPivotGrid;
            PivotGridField dField = pivot.Fields["Quantity"];
            object n = e.GetCellValue(dField);
            if (n == null) return;
            object v = e.GetCellValue(
                GetFieldValues(e.GetColumnFields(), e, (percentOfRow ? 1 : 0)),
                GetFieldValues(e.GetRowFields(), e, (percentOfRow ? 0 : 1)),
                dField);
            v = (Convert.ToDecimal(v) == 0) ? 1 : (Convert.ToDecimal(n) / Convert.ToDecimal(v));
            e.DisplayText = string.Format("{0:p0}", v);
        }

        object[] GetFieldValues(PivotGridField[] fields, PivotCellDisplayTextEventArgs e, int level)
        {
            if (fields.Length < level) return null;
            object[] values = new object[fields.Length-level];
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = e.GetFieldValue(fields[i]);
            }
            return values;
        }

    }

}
