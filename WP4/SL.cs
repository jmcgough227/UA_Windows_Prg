using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data.SqlClient;


public class SLPage : Page
{
    protected Table RecordTable;
    protected Button NewRecord;
    protected Button ModRecord;
    protected Button DelRecord;

    public void Page_Init()
    {
        table_init();
        display_records();

        access_database();
    }

    // Initialize the record table header
    public void table_init()
    {
        TableRow row1 = new TableRow();
        TableCell cell11 = new TableCell();
        TableCell cell12 = new TableCell();
        TableCell cell13 = new TableCell();
        TableCell cell14 = new TableCell();
        TableCell cell15 = new TableCell();
        TableCell cell16 = new TableCell();

        cell11.Text = "Name";
        cell12.Text = "Phone#";
        cell13.Text = "Address";
        cell14.Text = "DOB";
        cell15.Text = "Facebook";
        cell16.Text = "Twitter";
        row1.Cells.Add(cell11);
        row1.Cells.Add(cell12);
        row1.Cells.Add(cell13);
        row1.Cells.Add(cell14);
        row1.Cells.Add(cell15);
        row1.Cells.Add(cell16);

        row1.CssClass = "tableHeadRow";

        RecordTable.Rows.Add(row1);
    }

    // Access the social record database
    public void access_database()
    {
        SqlConnection conn = new SqlConnection("Server=localhost; Database=db; Integrated Security=true; Trusted_Connection=true; user id=root; pwd=sqlPass-01");
        SqlDataReader rdr = null;

        try
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM social_records", conn);

            rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                Response.Write(rdr[0]);
            }
        }
        catch(Exception e)
        {
            Response.Write(e.Message);
        }
        finally
        {
            if (rdr != null) rdr.Close();
            if (conn != null) conn.Close();
        }
    }

    // Loads and displays records from database in the record table
    // Hard-coded at the moment
    public void display_records()
    {
        TableRow row = new TableRow();
        TableCell cell1 = new TableCell();
        TableCell cell2 = new TableCell();
        TableCell cell3 = new TableCell();
        TableCell cell4 = new TableCell();
        TableCell cell5 = new TableCell();
        TableCell cell6 = new TableCell();

        cell1.Text = "Jason M.";
        cell2.Text = "(999) 555-1337";
        cell3.Text = "150 Drangleic Ave.";
        cell4.Text = "11/05/1605";
        cell5.Text = "Link: Jason M. Page";
        cell6.Text = "Link: Jason M. Feed";

        row.Cells.Add(cell1);
        row.Cells.Add(cell2);
        row.Cells.Add(cell3);
        row.Cells.Add(cell4);
        row.Cells.Add(cell5);
        row.Cells.Add(cell6);

        RecordTable.Rows.Add(row);
    }

    // Adds a new record to the database
    public void add_record()
    {

    }

    // Modifies an existing record in the database
    public void modify_record()
    {

    }

    // Deletes an existing record in the database
    public void delete_record()
    {

    }
}

