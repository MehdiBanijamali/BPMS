using System.Data;
using System.Data.SqlClient;

namespace BPMS.Infrastructure.Data
{
    public class DatabaseQuery : DatabaseBase
    {
        public DataTable GetUsers()
        {
            return ExecuteQuery("SELECT * FROM Users");
        }

        public int InsertUser(string name, string email)
        {
            return ExecuteNonQuery(
                "INSERT INTO Users (Name, Email) VALUES (@Name, @Email)",
                new SqlParameter("@Name", name),
                new SqlParameter("@Email", email)
            );
        }

        public object GetUserCount()
        {
            return ExecuteScalar("SELECT COUNT(*) FROM Users");
        }
    }
}
