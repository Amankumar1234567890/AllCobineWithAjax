using AllCobineWithAjax.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AllCobineWithAjax.ContextAndRepo
{
    public class DapperRepo
    {
        private readonly DapperContext _dc;
        public DapperRepo( DapperContext dc)
        {
            _dc = dc;
        }
        public List<Student> DisplayData()
        {
            using(var connection=_dc.Connection())
            {
                connection.Open();
                return connection.Query<Student>("DisplayData", commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public void InsertData(Student stu)
        {
            using(var connection=_dc.Connection())
            {
                connection.Open();
                connection.Execute("InsertData", new { stu.StudentName, stu.StudentClass }, commandType: CommandType.StoredProcedure);
            }
        }

        public void Delete(int studentId)
        {
            using (var connection = _dc.Connection())
            {
                connection.Open();
                connection.Execute("DeleteData", new { studentId }, commandType: CommandType.StoredProcedure);
            }
        }
        public void UpdateData(Student stu)
        {
            using (var connection = _dc.Connection())
            {
                connection.Open();
                connection.Execute("UpdateData", new { stu.StudentId,stu.StudentName,stu.StudentClass }, commandType: CommandType.StoredProcedure);
            }
        }
    } 
}
