﻿namespace TestNinja.Mocking
{
    public class EmployeeStorage : IEmployeeStorage
    {
        private readonly EmployeeContext _db;

        public EmployeeStorage()
        {
            _db = new EmployeeContext();
        }

        public void DeleteEmployee(int id)
        {
            var employee = _db.Employees.Find(id);

            if (employee == null) return;

            _db.Employees.Remove(employee);
            _db.SaveChanges();
        }
    }
}
