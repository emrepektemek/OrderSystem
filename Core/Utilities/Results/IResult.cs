using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    // API'de result dondurecek voidler icin yaptik bu sayede response nesnesini dondurebilecegiz 
    public interface IResult
    {
        bool Success {  get; }  // sadece okunabilir
        string Message { get; }

    }
}
