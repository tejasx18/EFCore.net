namespace EFCore.Models
{
    public class UsersCRUD
    {
        private readonly ApplicationDBContext db;
        public UsersCRUD(ApplicationDBContext db) {
            this.db = db;
        }

        public IEnumerable<User> GetUsers() { 
            return db.Users.ToList();
        }

        public User GetUserById(int id) {
            return db.Users.Where(x => x.Id == id).SingleOrDefault();      
        }

        public User GetUserByEmail(string email)
        {
            return db.Users.Where(x => x.Email.Equals(email)).FirstOrDefault();
        }
        public int AddUser(User user) {
            int result = 0;
            db.Users.Add(user);
            result = db.SaveChanges();
            return result;
        }

        public int UpdateUser(User user) {
            int result = 0;
            var u = db.Users.Where(x => x.Id == user.Id).SingleOrDefault();
            if (u != null) { 
                u.UserName = user.UserName;
                u.Email = user.Email;
                u.Password = user.Password;
                result=db.SaveChanges();
            }
            return result;
        }

        public int DeleteUser(int id) {
            int result = 0;
            var u = db.Users.Where(x => x.Id == id).SingleOrDefault();
            if (u != null)
            {
                db.Users.Remove(u);
                result = db.SaveChanges();
            }
            return result;
        }


    }
}
