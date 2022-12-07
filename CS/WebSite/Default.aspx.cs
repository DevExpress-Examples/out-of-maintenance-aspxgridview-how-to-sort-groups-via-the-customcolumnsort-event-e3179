using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DevExpress.Web;
using System.Collections;

public partial class _Default : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {

    }
    protected void gridCustomers_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e) {
        if (e.Column.FieldName == "City") {
            int groupLevel = gridCustomers.GetRowLevel(e.VisibleRowIndex);
            if (groupLevel == e.Column.GroupIndex) {
                string city = gridCustomers.GetRowValues(e.VisibleRowIndex, "City").ToString();
                string country = gridCustomers.GetRowValues(e.VisibleRowIndex, "Country").ToString();
                e.DisplayText = city + " (" + country + ")";
            }
        }

    }
    protected void gridCustomers_CustomColumnSort(object sender, CustomColumnSortEventArgs e) {
        if (e.Column != null & e.Column.FieldName == "City") {
            object country1 = e.GetRow1Value("Country");
            object country2 = e.GetRow2Value("Country");
            int res = Comparer.Default.Compare(country1, country2);
            if (res == 0) {
                object city1 = e.Value1;
                object city2 = e.Value2;
                res = Comparer.Default.Compare(city1, city2);
            }
            e.Result = res;
            e.Handled = true;
        }
    }
}
