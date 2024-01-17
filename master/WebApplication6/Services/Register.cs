using WebApplication6.Models;
using WebApplication6.Models;
namespace WebApplication6.Services
{
    public class Register
    {
        private static readonly AppDbContext _Db=new AppDbContext();

       

        public static registration? login(registration u)
        {
            var user = _Db.regist.Where(x => x.Password == u.Password && x.Email == u.Email).FirstOrDefault();
            if (user != null)
            {
                return user;
            }
            else
            {

                return null;
            }

        }

        public static registration? signup(registration _user)
        {


            var check = _Db.regist.FirstOrDefault(s => s.Email == _user.Email || s.username == _user.username);
            if (check == null)
            {
                _Db.regist.Add(_user);
                _Db.SaveChanges();
                return check;

            }
            else
            {
                return null;
            }





        }
    }
}
