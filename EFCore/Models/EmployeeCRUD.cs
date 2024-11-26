namespace EFCore.Models
{
    public class EmployeeCRUD
    {
        private readonly ApplicationDBContext db;
        public EmployeeCRUD(ApplicationDBContext db)
        {
            this.db = db;
        }
        public IEnumerable<Employee> GetEmployees()
        {
            // LINQ

            //var result = from e in db.Employees
            //             select e;

            //return result;

            // Lambda
            return db.Employees.ToList();
        }
        public Employee GetEmployeeById(int id)
        {
            //LINQ
            //var result= (from e in db.Employees
            //            where e.EmpId==id
            //            select e).SingleOrDefault();
            //return result;

            // Lambda

            return db.Employees.Where(x => x.EmpId == id).SingleOrDefault();
        }
        public int AddEmployee(Employee emp)
        {
            int result = 0;
            // add data in the DbSet 
            db.Employees.Add(emp);  // Add() will add emp object in the DbSet
            // update changes to Db
            result = db.SaveChanges();
            return result;
        }
        public int UpdateEmployee(Employee emp)
        {
            int result = 0;
            // search the data that we need to modify in the DbSet
            var e = db.Employees.Where(x => x.EmpId == emp.EmpId).SingleOrDefault();
            if (e != null)
            {
                //update new changes
                e.Name = emp.Name;
                e.Email = emp.Email;
                e.Salary = emp.Salary;
                // update the changes to DB
                result = db.SaveChanges();
            }
            return result;
        }
        public int DeleteEmployee(int id)
        {
            int result = 0;
            // search the data that we need to modify in the DbSet
            var e = db.Employees.Where(x => x.EmpId == id).SingleOrDefault();
            if (e != null)
            {
                //remove from DbSet
                db.Employees.Remove(e);
                // update the changes to DB
                result = db.SaveChanges();
            }
            return result;
        }

    }
}
