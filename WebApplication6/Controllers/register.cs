using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication6.Models;


public class register 
{
    private static readonly AppDbContext _Db=new AppDbContext();
       
    public static registration? login(registration u)
    {
        var user=_Db.regist.Where(x => x.Password == u.Password && x.username == u.username).FirstOrDefault();
        if (user != null)
        {
            return user;
        }
        else
        {
      
            return null;
        }
            
    }
 
    public static registration? signup (registration _user)
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


