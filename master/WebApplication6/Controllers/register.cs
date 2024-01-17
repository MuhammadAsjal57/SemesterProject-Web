
using Microsoft.AspNetCore.Mvc;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class register 
    {
        private  readonly AppDbContext _Db ;

        public  register(AppDbContext db)
        {
            _Db = db;
        }

        public  registration? login(registration u)
        {
            var user = _Db.regist.Where(x => x.Password == u.Password && x.username == u.username).FirstOrDefault();
            if (user != null)
            {
                return user;
            }
            else
            {

                return null;
            }

        }

        public  registration? signup(registration _user)
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