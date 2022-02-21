using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace SQL_TEST
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int count = 0;
            ////SQL 접속정보
            //string connectionString = "server=LAPTOP-XINNOS\\SQLEXPRESS;" +
            //                            "uid=sa; pwd=1234;database=song; ";

            ////SQL 접속정보 반영(적용)
            //SqlConnection sqlConn = new SqlConnection();
            //sqlConn.ConnectionString = connectionString;
            //// DB 연결
            //sqlConn.Open();
            //// 쿼리 생성
            //SqlCommand sqlComm = new SqlCommand();
            //// 쿼리 명령을 연결된 DB(sqlConn)으로 전달
            //sqlComm.Connection = sqlConn;
            //// 쿼리 매핑
            //sqlComm.CommandText = "select * from dbo.airplane";
            ////쿼리 결과 불러와서 저장
            //SqlDataReader SqlRs = sqlComm.ExecuteReader();
            //{
            //    Console.WriteLine("col1\tcol2\tcol3\tcol4\tcol5");
            //    while(SqlRs.Read())
            //    {

            //        count++;
            //        Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", SqlRs[0], SqlRs[1], SqlRs[2], SqlRs[3], SqlRs[4]);
            //    }
            //    Console.WriteLine(count);
            //}
            //sqlConn.Close();




            //SqlConnection conn = new SqlConnection();
            //conn.ConnectionString = "server=LAPTOP-XINNOS\\SQLEXPRESS;" +
            //                            "uid=sa; pwd=1234;database=song; ";
            ////SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM dbo.airplane",conn);
            ////SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM dbo.butterfly", conn);
            //SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM dbo.schoolbell", conn);
            //DataSet ds = new DataSet();
            ////adapter.Fill(ds, "airplane");
            ////adapter.Fill(ds, "butterfly");
            //adapter.Fill(ds, "schoolbell");
            //foreach (DataRow row in ds.Tables[0].Rows)
            //{
            //    //string i = row[0].ToString();
            //    //Console.WriteLine(i.GetType());
            //    //int k = Convert.ToInt32(i);
            //    //Console.WriteLine(k.GetType());
            //    Console.WriteLine("{0} {1} {2} {3} {4}" ,row[0], row[1], row[2], row[3], row[4]);
            //}
            //Console.ReadKey();
            double x,y;
            x = Math.Cos(18*Math.PI/180) * 150;
            y = Math.Sin(18*Math.PI/180) * 150;
            Console.WriteLine(x);
            Console.WriteLine(y);
            Console.ReadKey();
        }
    }
}
