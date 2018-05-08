using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RESTwebserviceVejrstation
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private const string ConnectionString =
            "Server=tcp:myservereasj.database.windows.net,1433;Initial Catalog=mydatabase;Persist Security Info=False;User ID=Serveradmin;Password=Test12345;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public List<Vejrstation> GetAll()
        {
            //listen der skal vises i browseren
            List<Vejrstation> OList = new List<Vejrstation>();

            const string sqlstring = "SELECT Temperatur, Timer, Minutter, Luftfugtighed FROM dbo.Vejrstation";
            
            using (var DBconnection = new SqlConnection(ConnectionString))
            {
                DBconnection.Open();
                var sqlcommand = new SqlCommand(sqlstring, DBconnection);

                using (SqlDataReader reader = sqlcommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Vejrstation vejrstation = new Vejrstation();
                        vejrstation.Temperatur = reader.GetString(0).Trim();
                        vejrstation.Timer = reader.GetString(1).Trim();
                        vejrstation.Minutter = reader.GetString(2).Trim();
                        vejrstation.Luftfugtighed = reader.GetString(3).Trim();
                          //trim fjerne whitespaces. 

                        OList.Add(vejrstation);
                    }
                }
                return OList;
            }



        }
        public int InsertFeedbackDB(string temperatur, string timer, string minutter, string luftfugtighed)
        {
            const string insertStudent =
                "insert into Vejrstation (temperatur,  timer, minutter, luftfugtighed) values (@temperatur, @timer, @minutter, @luftfugtighed)";
            using (SqlConnection databaseConnection = new SqlConnection(ConnectionString))
            {
                databaseConnection.Open();
                using (SqlCommand insertCommand = new SqlCommand(insertStudent, databaseConnection))
                {
                    insertCommand.Parameters.AddWithValue("@Temperatur", temperatur);
                    insertCommand.Parameters.AddWithValue("@Timer", minutter);
                    insertCommand.Parameters.AddWithValue("@Minutter", minutter);
                    insertCommand.Parameters.AddWithValue("@Luftfugtighed", luftfugtighed);
                    int rowsAffected = insertCommand.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
