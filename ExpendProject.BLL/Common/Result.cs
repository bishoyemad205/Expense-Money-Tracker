using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpendProject.BLL.Common
{
    public record Result(bool Succes , string ? Error = null , Resultkind kind = Resultkind.ok)
    {
        public static Result ok()=> new Result(true);
        public static Result Fail(string ErrorMessagge , Resultkind kind = Resultkind.Conflict ) => new Result(false , ErrorMessagge);
        public static Result NotFound(string ErrorMessagge, Resultkind kind = Resultkind.NotFound) => new Result(false, ErrorMessagge);
        public static Result Validation(string ErrorMessagge, Resultkind kind = Resultkind.ValidationFailed) => new Result(false, ErrorMessagge);

    }
    public record Result<T>(bool Succes, T? Value, string? Error=null, Resultkind kind = Resultkind.ok)
    { 
        public static Result<T> ok(T value)=> new (true,value ) ;
        public static Result<T> Fail(string ErrorMessagge, Resultkind kind = Resultkind.Conflict) => new(false, default, ErrorMessagge, kind);
        public static Result<T> NotFound(string ErrorMessagge , Resultkind kind = Resultkind.NotFound)=> new (false, default, ErrorMessagge,Resultkind.NotFound);


    }
    public enum Resultkind
    { 
       ok ,
       NotFound ,
       ForBiddin ,
       ValidationFailed ,
       Conflict ,
    
    }
}
