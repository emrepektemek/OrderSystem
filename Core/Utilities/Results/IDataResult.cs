using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    /* Busniess katmaninda  IProductService'de kurallar yazip data access metodlarini kullanarak veri tabani islemlerini yapiyorduk
     * fakat bunları API'ye acmak istedigimizde API'yi kullanana response dondurmemiz lazim. Response dondurmak icinde metodun birden fazla
     * tur dondurmesi lazim. Void ler icin IResult ile yeterliydi cunku void zaten bir deger dondurmuyordu  sadece result nesnesini
     * dondurmek yeterliydi onun icim IResult, Result, ErrorResult ve SuccessResult yeterliydi FAKAT List<Product>'in kullanildi yerlerde
     * hem API result'u (result icinde islemin gerceklesip gerceklemediği ve message iceriyor  ) hem de List<Product> gibi bir data
     * dondurmemiz gerekiyor ISTE bunu yapabilmek icin IDataResult interface'ini olusturduk VEEEEE Business katmaninda Manager'larda 
     * her List<...> gordugun yere IDataResult koyarak hem API sonucunu hem de mesajlarini ayni anda gonderebilecegiz
     * 
     * 
     * List<Product> */

    /*Bak yine tekrara dusmemek icin ben IDateResult a hem Message hem de  Success ekleyecektim fakat bu alanlar zaten 
     IResult'da var o yuzden hemen onu implemente ettik bu sayede kod tekrarina yapmadik ve bir interface diğer bir interface'i implemente 
     ettiginde dolayisiyla base interface'de ki alanlari tekrardan yazmaya gerek yok fakat sinifa implemente etseydik o zaman
     yazilirdi
    */
    public interface IDataResult<T>: IResult
    {
        T Data { get; }    

    }
}
