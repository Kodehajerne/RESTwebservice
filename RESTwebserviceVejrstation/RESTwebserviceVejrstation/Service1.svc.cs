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

        public List<Dataset> GetAll()
        {
            //listen der skal vises i browseren
            List<Dataset> OList = new List<Dataset>();

            const string sqlstring = "SELECT Temperatur, Dato, Luftfugtighed FROM dbo.Vejrstation";
            
            using (var DBconnection = new SqlConnection(ConnectionString))
            {
                DBconnection.Open();
                var sqlcommand = new SqlCommand(sqlstring, DBconnection);

                using (SqlDataReader reader = sqlcommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Dataset dataset = new Dataset();
                        dataset.Temperatur = reader.GetString(0).Trim();
                        dataset.Dato = reader.GetString(1).Trim();
                        dataset.Luftfugtighed = reader.GetString(2).Trim();
                          //trim fjerne whitespaces. 

                        OList.Add(dataset);
                    }
                }
                return OList;
            }
        }
    }
}
