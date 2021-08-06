using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ////create a csv file
            string filePath = @"test.csv";
            string delimiter = ",";
            string[][] output = new string[][]{
                  new string[]{"Name", "Surname", "Age","Date of Birth","Place"},
                  new string[]{"Apple", "A", "10","1990/3/4","USA" },
                  new string[]{"Bob", "B", "11","1991/3/4","China" },
                  new string[]{"Cherry", "C", "12","1992/3/4","Japan" }
              };
            int length = output.GetLength(0);
            StringBuilder sb = new StringBuilder();
            for (int index = 0; index < length; index++)
               sb.AppendLine(string.Join(delimiter, output[index]));
            File.WriteAllText(filePath, sb.ToString());

            //comvert vsc to datatable
            var table = ConvertCSVtoDataTable("test.csv");

            //get value of special column
            string[] columnName = { "Name", "Surname", "Age" };

            for (int i = table.Columns.Count - 1; i >= 0; i--)
            {
                DataColumn dc = table.Columns[i];
                if (!columnName.Contains(dc.ColumnName))
                {
                    table.Columns.Remove(dc);
                }
            }

            WriteDataToFile(table, "datatable.txt");
        }
        public static DataTable ConvertCSVtoDataTable(string strFilePath)
        {
            StreamReader sr = new StreamReader(strFilePath);
            string[] headers = sr.ReadLine().Split(',');
            DataTable dt = new DataTable();
            foreach (string header in headers)
            {
                dt.Columns.Add(header);
            }
            while (!sr.EndOfStream)
            {
                string[] rows = Regex.Split(sr.ReadLine(), ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
                DataRow dr = dt.NewRow();
                for (int i = 0; i < headers.Length; i++)
                {
                    dr[i] = rows[i];
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        public static void WriteDataToFile(DataTable submittedDataTable, string submittedFilePath)
        {
            int i = 0;
            StreamWriter sw = null;

            sw = new StreamWriter(submittedFilePath, false);

            for (i = 0; i < submittedDataTable.Columns.Count - 1; i++)
            {

                sw.Write(submittedDataTable.Columns[i].ColumnName + ";");

            }
            sw.Write(submittedDataTable.Columns[i].ColumnName);
            sw.WriteLine();

            foreach (DataRow row in submittedDataTable.Rows)
            {
                object[] array = row.ItemArray;

                for (i = 0; i < array.Length - 1; i++)
                {
                    sw.Write(array[i].ToString() + ";");
                }
                sw.Write(array[i].ToString());
                sw.WriteLine();

            }

            sw.Close();
        }
    }
}
