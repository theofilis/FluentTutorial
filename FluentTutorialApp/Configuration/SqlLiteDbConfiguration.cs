using FluentNHibernate.Cfg.Db;
using NHibernate.Dialect;

namespace FluentTutorialApp.Configuration
{
    public class SqlLiteDbConfiguration : PersistenceConfiguration<SqlLiteDbConfiguration>
    {
        public static SqlLiteDbConfiguration Standard => new SqlLiteDbConfiguration();

        private SqlLiteDbConfiguration()
        {
            Driver<SqlLiteDriver>();
            Dialect<SQLiteDialect>();
            Raw("query.substitutions", "true=1;false=0");  
        }

        public SqlLiteDbConfiguration InMemory()
        {
            return ConnectionString(c => c
                .Is("Data Source=:memory:"));
            
        }

        public SqlLiteDbConfiguration UsingFile(string fileName)
        {
            return ConnectionString(c => c
                .Is(string.Format("Data Source={0};", fileName)));
        }

        public SqlLiteDbConfiguration UsingFileWithPassword(string fileName, string password)
        {
            return ConnectionString(c => c
                .Is(string.Format("Data Source={0};Password={1};", fileName, password)));
        }
    }
}
