//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace autopark
{
    using System;
    using System.Collections.Generic;
    
    public partial class Продажи
    {
        public int ID_Цены { get; set; }
        public int ID_Клиента { get; set; }
        public int ID_Автомобиля { get; set; }
        public System.DateTime Дата_Продажи { get; set; }
        public int Цена { get; set; }
        public string Способ_Оплаты { get; set; }
    
        public virtual Автомобили Автомобили { get; set; }
        public virtual Клиенты Клиенты { get; set; }
    }
}
