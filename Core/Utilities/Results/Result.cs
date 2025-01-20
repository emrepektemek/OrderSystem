using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {

        /* this bildigin gibi sinifi temsil ediyor yani bu ornekte Result sinifini. (success) ise tek parametreli 
         * kurucu fonksiyon anlamina gelir yani :this(success) kodu  success'i Reuslt sinifin tek parametreli olan kurucu 
         * fonksiyonuna yolla demektir bunu yaparak Message i 2 parametreli kurucu icinde set ettik ve success'i de tek parametreli
         kurucu icinde set ettik. Bunu yapmamizin sebebi success set ederken tekrar etmesi ve bunu yaparak tekrari onledik*/
        public Result(bool success, string message ): this(success) 
        {
            Message = message;  
        }

        public Result(bool success)
        {
            Success = success;
        }

        public bool Success {  get; }  

        public string Message { get; }


    }
}
