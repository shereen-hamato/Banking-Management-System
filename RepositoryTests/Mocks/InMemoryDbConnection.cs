using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text.RegularExpressions;
using Entity;
using Repository;

namespace RepositoryTests.Mocks
{
    public class InMemoryDbConnection : DatabaseConnectionClass
    {
        private readonly Dictionary<string, Customer> _customers = new Dictionary<string, Customer>();

        public override void ConnectWithDB() { }
        public override void CloseConnection() { }

        public override int ExecuteSQL(string query)
        {
            // Very naive parser for INSERT queries used in tests
            var match = Regex.Matches(query, "'([^']*)'");
            if (match.Count >= 3)
            {
                var id = match[0].Groups[1].Value;
                var name = match[1].Groups[1].Value;
                var phone = match[2].Groups[1].Value;
                _customers[id] = new Customer { CustId = id, Name = name, PhnNumber = phone };
                return 1;
            }
            return 0;
        }

        public override IDataReader GetData(string query)
        {
            var m = Regex.Match(query, "WHERE custId = '([^']*)'", RegexOptions.IgnoreCase);
            if (m.Success && _customers.TryGetValue(m.Groups[1].Value, out var cust))
            {
                var table = new DataTable();
                table.Columns.Add("CustId");
                table.Columns.Add("Name");
                table.Columns.Add("PhnNumber");
                table.Rows.Add(cust.CustId, cust.Name, cust.PhnNumber);
                return table.CreateDataReader();
            }
            return (new DataTable()).CreateDataReader();
        }
    }
}
