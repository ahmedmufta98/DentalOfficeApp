using ClosedXML.Excel;
using DentalOffice.Dtos;
using Npgsql;
using System.Data;

namespace DentalOffice.WinFormsUI.Forms.Report
{
    public partial class rptDentistMvp : Form
    {
        public rptDentistMvp()
        {
            InitializeComponent();
        }

        private void rptDentistMvp_Load(object sender, EventArgs e)
        {
            dgvMvpDentist.AutoGenerateColumns = false;
            List<ReportDto> reportData = new();

            using (NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Database=db_dentaloffice;User Id=postgres;Password=postgres;"))
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(@"SELECT d.""FirstName"" || ' ' || d.""LastName"" AS DentistFullName, ROUND(SUM(r.""Rate"") / COUNT(r.""DentistId""), 2) AS AverageRate

                                                  FROM public.""Ratings"" as r
                                                  JOIN public.""Dentists"" as d on d.""Id"" = r.""DentistId""
	                                              GROUP BY 1

                                                  ORDER BY 2 DESC", conn);
                NpgsqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ReportDto data = new()
                    {
                        DentistFullName = dr[0].ToString(),
                        AverageRate = decimal.Parse(dr[1].ToString())
                    };
                    reportData.Add(data);
                }

                dr.Close();
            }

            dgvMvpDentist.ReadOnly = true;
            dgvMvpDentist.DataSource = reportData;
        }

        private void btnGenerateExcel_Click(object sender, EventArgs e)
        {
            if (dgvMvpDentist.Rows.Count > 0)
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
                {
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            using (XLWorkbook workbook = new XLWorkbook())
                            {
                                string query = $@"SELECT d.""FirstName"" || ' ' || d.""LastName"" AS DentistFullName, ROUND(SUM(r.""Rate"")/COUNT(r.""DentistId""),2) AS AverageRate
	                                              FROM public.""Ratings"" as r
	                                              JOIN public.""Dentists"" as d on d.""Id"" = r.""DentistId""
	                                              GROUP BY 1
	                                              ORDER BY 2 DESC";

                                NpgsqlConnection conn = new("Server=localhost;Database=db_dentaloffice;User Id=postgres;Password=postgres;");
                                NpgsqlDataAdapter dataAdapter = new(query, conn);
                                NpgsqlCommandBuilder commandBuilder = new(dataAdapter);
                                DataSet ds = new DataSet();
                                dataAdapter.Fill(ds);
                                workbook.Worksheets.Add(ds.Tables[0]);
                                workbook.SaveAs(saveFileDialog.FileName);

                                MessageBox.Show("You have successfuly exported your data to excel file!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}
